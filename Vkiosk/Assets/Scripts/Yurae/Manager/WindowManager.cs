// Unity
using UnityEngine;

// DOT
using DG.Tweening;

[DisallowMultipleComponent]
public class WindowManager : MonoBehaviour
{
    [SerializeField] private float rotationTime = 0.5f;
    private Window[] windows;
    private Window currentWindow;

    private bool canRotate;

    private void Start()
    {
        canRotate = true;
    }

    public void InitWindows()
    {
        windows = GetComponentsInChildren<Window>();

        CancelAllWindow();

        currentWindow = windows[0];

        for (int i = 1; i < windows.Length; i++)
        {
            if (currentWindow.transform.position.z > windows[i].transform.position.z)
            {
                currentWindow = windows[i];
            }
        }

        currentWindow.SetCurrentWindow();
    }

    public void CancelAllWindow()
    {
        foreach(Window window in windows)
        {
            window.CancelCurrentWindow();
        }
    }

    private void Update()
    {
        // Test
        if (Input.GetKeyDown(KeyCode.R)) RotationWindow(-1);
        if (Input.GetKeyDown(KeyCode.L)) RotationWindow(1);
    }

    public void RotationWindow(int _direction)
    {
        if (!canRotate) return;

        canRotate = false;
        CancelAllWindow();

        float targetY = transform.eulerAngles.y + (360f / windows.Length) * _direction;

        transform.DORotate(new Vector3(0, targetY, 0), rotationTime, RotateMode.FastBeyond360)
         .OnComplete(() =>
         {
             canRotate = true;
             InitWindows();
         });
    }

    public Window GetCurrentWindow()
    {
        return currentWindow;
    }
}
