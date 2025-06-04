using TMPro;
using UnityEngine;

public class CategoryWindow : Window
{
    [Header("Window Info")]
    [SerializeField] private TextMeshProUGUI categoryTitle;

    /// <summary>
    /// 윈도우 TMP 업데이트
    /// </summary>
    /// <param name="_title"></param>
    public void UpdateInfoToCategoryWindow(string _title)
    {
        categoryTitle.text = _title;
    }
}
