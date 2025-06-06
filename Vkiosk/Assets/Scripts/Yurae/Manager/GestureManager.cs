// Unity
using UnityEngine;

[DisallowMultipleComponent]
public class GestureManager : MonoBehaviour
{
    [SerializeField] private WindowGrabber windowGrabber;
    [SerializeField] private ViewController sphereController;
    [SerializeField] private UIManager uiManager;

    private bool isStart;

    private void Start()
    {
        isStart = false;
    }

    public void UpdateGestureFromNetwork(string gesture)
    {
        WindowManager windowManager = FindObjectOfType<WindowManager>();

        if (gesture == "start")
        {
            isStart = true;
            uiManager.StartToSelect();
        }
        if (!isStart) return;

        switch (gesture)
        {
            case "up_swipe":
                sphereController.CategoryToMenu();
                break;
            case "down_swipe":
                sphereController.MenuToCategory();
                break;
            case "left_swipe":
                windowManager.RotationWindow(1);
                break;
            case "right_swipe":
                windowManager.RotationWindow(-1);
                break;
            case "grab": windowGrabber.GrabWindow(); break;
            case "drop": windowGrabber.DropWindow(); break;
        }
    }
}
