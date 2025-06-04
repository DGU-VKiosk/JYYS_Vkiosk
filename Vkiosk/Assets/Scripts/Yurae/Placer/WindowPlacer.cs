// Unity
using UnityEngine;

public interface IWindowPlacer
{
    void PlaceWindow(int _windowCount, GameObject _prefab);
    void InitWindow(Window _window, int _index);
}

public abstract class WindowPlacer : MonoBehaviour, IWindowPlacer
{
    [SerializeField] private WindowManager windowManager;
    [SerializeField] private float offSet;

    public virtual void Place() { }

    public virtual void PlaceWindow(int _windowCount, GameObject _prefab)
    {
        Transform reference = Camera.main.transform;
        Vector3 baseDir = reference.forward;
        baseDir.y = 0;
        baseDir.Normalize();

        for (int i = 0; i < _windowCount; i++)
        {
            float angle = 360f / _windowCount * i;

            Vector3 dir = Quaternion.Euler(0, angle, 0) * (-baseDir);

            Vector3 position = transform.position + dir * offSet;

            Window window = Instantiate(_prefab, position, Quaternion.identity).GetComponent<Window>();

            InitWindow(window, i);
            window.SetWindowID(i);

            window.transform.rotation = Quaternion.Euler(0, 0, 0);
            window.transform.SetParent(transform);
        }

        windowManager.InitWindows();
    }

    public virtual void InitWindow(Window _window, int _index) { }
}

    

