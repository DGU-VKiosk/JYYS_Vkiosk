// Unity
using UnityEngine;
using DG.Tweening;

public class ViewController : MonoBehaviour
{
    [SerializeField] private CategoryPlacer categoryPlacer;
    [SerializeField] private WindowManager categoryWindow;

    [SerializeField] private MenuPlacer[] menuPlacer;

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
    }

    public void CategoryToMenu()
    {
        if (currentMenuSphere != null || GetCurrentCategoryID() >= menuPlacer.Length) return;

        categoryPlacer.gameObject.SetActive(false);
        menuPlacer[GetCurrentCategoryID()].gameObject.SetActive(true);
        currentMenuSphere = menuPlacer[GetCurrentCategoryID()].gameObject;
    }

    public void MenuToCategory()
    {
        if (currentMenuSphere == null) return;

        currentMenuSphere.SetActive(false);
        currentMenuSphere = null;
        categoryPlacer.gameObject.SetActive(true);
    }

    private int GetCurrentCategoryID()
    {
        return categoryWindow.GetCurrentWindow().GetWindowID();
    }
}
