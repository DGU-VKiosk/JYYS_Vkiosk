// Unity
using UnityEngine;

[System.Serializable]
public class MenuWindowInfo
{
    public string title;
    public string description;
}

public class MenuPlacer : WindowPlacer
{
    [Header("�� ī�װ��� ���� ���� Ŭ����")]
    [SerializeField] private MenuWindowInfo[] windows;

    [Header("ī�װ� ������ ������")]
    [SerializeField] private GameObject windowPrefab;

    public override void Place()
    {
        PlaceWindow(windows.Length, windowPrefab);
    }

    public override void InitWindow(Window _window, int _index)
    {
        _window.UpdateInfoToMenuWindow(windows[_index].title, windows[_index].description);
    }
}
