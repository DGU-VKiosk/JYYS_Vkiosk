// Unity
using UnityEngine;

/// <summary>
/// 메뉴 윈도우에 들어가는 정보 클래스
/// </summary>
[System.Serializable]
public class MenuWindowInfo
{
    public string title;
    public string description;
}

public class MenuPlacer : WindowPlacer
{
    [SerializeField] private MenuWindowInfo[] windows;      // 윈도우 정보 클래스 배열
    [SerializeField] private GameObject windowPrefab;       // 윈도우 프리팹

    /// <summary>
    /// 윈도우 배치 메소드 오버라이딩
    /// </summary>
    public override void Place()
    {
        PlaceWindow(windows.Length, windowPrefab);
    }

    /// <summary>
    /// 윈도우 초기화 메소드 오버라이딩 (메뉴 이름, Description)
    /// </summary>
    /// <param name="_window"></param>
    /// <param name="_index"></param>
    public override void InitWindow(Window _window, int _index)
    {
        _window.UpdateInfoToMenuWindow(windows[_index].title, windows[_index].description);
    }
}
