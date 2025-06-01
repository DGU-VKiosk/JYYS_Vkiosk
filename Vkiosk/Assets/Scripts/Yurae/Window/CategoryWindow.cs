using TMPro;
using UnityEngine;

public class CategoryWindow : Window
{
    [Header("Window Info")]
    [SerializeField] private TextMeshProUGUI categoryTitle;

    public override void UpdateInfoToCategoryWindow(string _title)
    {
        categoryTitle.text = _title;
    }
}
