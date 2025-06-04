using TMPro;
using UnityEngine;

public class Menu : Window
{
    [Header("Window Info")]
    [SerializeField] private TextMeshProUGUI menuTitle;
    [SerializeField] private TextMeshProUGUI menuDescription;

    /// <summary>
    /// 윈도우 TMP 업데이트
    /// </summary>
    /// <param name="_title"></param>
    /// <param name="_description"></param>
    public override void UpdateInfoToMenuWindow(string _title, string _description)
    {
        menuTitle.text = _title;
        menuDescription.text = _description;
    }
}