// Unity
using UnityEngine;

[System.Serializable]
public class CategoryWindowInfo
{
    public string title;
}

public class CategoryPlacer : WindowPlacer
{
    [Header("�� ī�װ��� ���� ���� Ŭ����")]
    [SerializeField] private CategoryWindowInfo[] windows;

    [Header("ī�װ� ������ ������")]
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
