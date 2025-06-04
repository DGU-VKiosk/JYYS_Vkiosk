// Unity
using UnityEngine;
using TMPro;

public class ViewController : MonoBehaviour
{
    [SerializeField] private CategoryPlacer categoryPlacer;
    [SerializeField] private WindowManager categoryWindow;

    [SerializeField] private MenuPlacer[] menuPlacer;
    [SerializeField] private TextMeshProUGUI headerTMP;

    private GameObject currentMenuSphere;
    

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) CategoryToMenu();
        if (Input.GetKeyDown(KeyCode.V)) MenuToCategory();
    }

    public void Init()
    {
        categoryPlacer.Place();
        categoryPlacer.transform.rotation = Quaternion.Euler(0, 0, 0);

        foreach (WindowPlacer placer in menuPlacer)
        {
            placer.Place();
            placer.gameObject.SetActive(false);
        }

        categoryPlacer.gameObject.SetActive(false);
    }

    public void CategoryToMenu()
    {
        // 현재 메뉴 스페어가 활성화 되어 있거나, 없는 ID의 메뉴일 경우 Skip
        if (currentMenuSphere != null || GetCurrentCategoryID() >= menuPlacer.Length) return;

        categoryPlacer.gameObject.SetActive(false);
        menuPlacer[GetCurrentCategoryID()].gameObject.SetActive(true);  // 현재 카테고리 ID에 해당하는 메뉴 오브젝트 활성화

        currentMenuSphere = menuPlacer[GetCurrentCategoryID()].gameObject;

        headerTMP.text = "MENU";
    }

    public void MenuToCategory()
    {
        if (currentMenuSphere == null) return;

        currentMenuSphere.SetActive(false);

        currentMenuSphere = null;

        categoryPlacer.gameObject.SetActive(true);

        headerTMP.text = "CATEGORY";
    }

    private int GetCurrentCategoryID()
    {
        return categoryWindow.GetCurrentWindow().GetWindowID();
    }
}
