// Unity
using UnityEngine;

[System.Serializable]
public class CategoryWindowInfo
{
    public string title;
}

public class CategoryPlacer : WindowPlacer
{
    [SerializeField] private CategoryWindowInfo[] windows;
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
