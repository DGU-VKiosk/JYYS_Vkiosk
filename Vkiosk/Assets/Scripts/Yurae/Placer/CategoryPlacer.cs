// Unity
using UnityEngine;

[System.Serializable]
public class CategoryWindowInfo
{
    public string title;
}

public class CategoryPlacer : WindowPlacer
{
    [Header("각 카테고리에 대한 정보 클래스")]
    [SerializeField] private CategoryWindowInfo[] windows;

    [Header("카테고리 윈도우 프리팹")]
    [SerializeField] private GameObject windowPrefab;

    public override void Place()
    {
        PlaceWindow(windows.Length, windowPrefab);
    }

    public override void InitWindow(Window _window, int _index)
    {
        _window.UpdateInfoToCategoryWindow(windows[_index].title);
    }
}
