using TMPro;
using UnityEngine;

public class MenuWindow : Window
{
    [Header("Window Info")]
    [SerializeField] private TextMeshProUGUI menuName;
    [SerializeField] private TextMeshProUGUI menuDescription;

    /// <summary>
    /// 윈도우 TMP 업데이트
    /// </summary>
    /// <param name="_title"></param>
    /// <param name="_description"></param>
    public void UpdateInfoToMenuWindow(string _menuName, string _description)
    {
        menuName.text = _menuName;
        menuDescription.text = _description;
    }
}