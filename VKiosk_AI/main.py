from Camera import *
from PersonDetection import draw_person_boxes, track_persons
from HandTracking import detect_hands
from UserRegister import user_registration, user_unregisteration, draw_zone

import cv2
import time

# Initialize
zone = (440, 160, 880, 560) # Cognition Zone
cap = init_camera(0)        # Video Capture
registered_id = None        # Register ID
registered_box = None

boxes = []
track_ids = []

prev_time = time.time()

while True:
    start_time = time.time()        
    frame = get_camera_frame(cap)   # Get camera frame

    boxes, track_ids = track_persons(frame) # Get Person's box and id

    # Update registered id
    if registered_id is None:
        draw_zone(frame, zone)                                              # Draw cognition zone
        registered_id = user_registration(boxes, zone, track_ids)           # Wait user registration
    else:
        detect_hands(frame, boxes, registered_id, track_ids)                # Detect hands
        registered_id = user_unregisteration(registered_id, track_ids)      # Wait user unregistration

    # Draw person box
    draw_person_boxes(frame, boxes, registered_id, track_ids)

    # Compute FPS
    curr_time = time.time()
    fps = 1.0 / (curr_time - start_time)
    cv2.putText(frame, f"FPS: {fps:.2f}", (20, 40),
            cv2.FONT_HERSHEY_SIMPLEX, 1.0, (0, 0, 0), 2)

    # Display current frame
    cv2.imshow("Main", frame)

    # Exit Condition : Keycode.Q
    if cv2.waitKey(1) & 0xFF == ord('q'):   
        break

cap.release()
cv2.destroyAllWindows()
