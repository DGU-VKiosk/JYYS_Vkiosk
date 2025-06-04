// Unity
using UnityEngine;

[DisallowMultipleComponent]
public class WindowGrabber : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField] private GameObject grabbedWindow = null;        
    private float grabDistance = 0f;              
    private Vector3 grabOffset;

    private Vector3 lastWindowPosition;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Test Code
        if (Input.GetMouseButton(0)) GrabWindow();
        if (Input.GetMouseButtonUp(0)) DropWindow();
        MoveGrabbedWindow();
    }

    public void GrabWindow()
    {
        if (grabbedWindow == null)
        {
            // Ray : criteria is mouse position
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // if out is not null
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Window"))
                {
                    Window window = hit.transform.GetComponent<Window>();
                    
                    if (window.CanGrab())
                    {
                        grabbedWindow = hit.collider.gameObject;
                        lastWindowPosition = grabbedWindow.transform.position;

                        grabDistance = Vector3.Distance(mainCamera.transform.position, hit.point);
                        grabOffset = grabbedWindow.transform.position - hit.point;
                    }
                }
            }
        }
    }

    public void MoveGrabbedWindow()
    {
        if (grabbedWindow != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); 
            Vector3 targetPoint = ray.GetPoint(grabDistance);
            Vector3 newPos = new Vector3(targetPoint.x + grabOffset.x,
                                          targetPoint.y + grabOffset.y,
                                          lastWindowPosition.z);
            grabbedWindow.transform.position = newPos;    
        }
    }

    public void DropWindow()
    {
        if (grabbedWindow != null) grabbedWindow.transform.position = lastWindowPosition;

        grabbedWindow = null;
    }
}
