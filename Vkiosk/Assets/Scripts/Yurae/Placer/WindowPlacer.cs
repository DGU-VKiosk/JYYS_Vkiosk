// Unity
using UnityEngine;

/// <summary>
/// 윈도우를 배치하기 위한 인터페이스
/// </summary>
public interface IWindowPlacer
{
    /// <summary>
    /// 윈도우 배치 메소드
    /// </summary>
    /// <param name="_windowCount"></param>
    /// <param name="_prefab"></param>
    void PlaceWindow(int _windowCount, GameObject _prefab);

    /// <summary>
    /// 윈도우 초기화 메소드
    /// </summary>
    /// <param name="_window"></param>
    /// <param name="_index"></param>
    void InitWindow(Window _window, int _index);
}

/// <summary>
/// 윈도우 배치를 위한 추상 클래스 (IWindowPlacer Implement)
/// </summary>
public abstract class WindowPlacer : MonoBehaviour, IWindowPlacer
{
    [SerializeField] private WindowManager windowManager;
    [SerializeField] private float offSet;

    /// <summary>
    /// 윈도우 배치에 대한 가상 메소드 (인터페이스 메소드)
    /// </summary>
    public virtual void Place() { }

    /// <summary>
    /// 윈도우 배치 가상 메소드
    /// </summary>
    /// <param name="_windowCount"></param>
    /// <param name="_prefab"></param>
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

    /// <summary>
    /// 윈도우 초기화를 위한 메소드 (인터페이스 메소드)
    /// </summary>
    /// <param name="_window"></param>
    /// <param name="_index"></param>
    public virtual void InitWindow(Window _window, int _index) { }
}

    

