using TMPro;
using UnityEngine;

public class Menu : Window
{
    [Header("Window Info")]
    [SerializeField] private TextMeshProUGUI menuTitle;
    [SerializeField] private TextMeshProUGUI menuDescription;

    public override void UpdateInfoToMenuWindow(string _title, string _description)
    {
        menuTitle.text = _title;
        menuDescription.text = _description;
    }
}