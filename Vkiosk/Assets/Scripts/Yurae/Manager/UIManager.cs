// Unity
using UnityEngine;

using System;
using TMPro;

[DisallowMultipleComponent]
public class UIManager : MonoBehaviour
{
    [Header("Start Menu Canvas")]
    [SerializeField] private GameObject startCanvas;

    [Header("Select Order Canvas")]
    [SerializeField] private GameObject selectCanvas;

    [Header("Common Header Canvas")]
    [SerializeField] private GameObject headerCanvas;

    [Header("Common Floor Canavas")]
    [SerializeField] private GameObject floorCanvas;

    [Header("Cart Canvas")]
    [SerializeField] private GameObject cartCanvas;

    [Header("Pay Complete Canvas")]
    [SerializeField] private GameObject payCanvas;

    [Header("Menw Sphere")]
    [SerializeField] private GameObject[] menuSpheres;

    [Header("Category Sphere")]
    [SerializeField] private GameObject categorySphere;

    [Header("UDP Receiver")]
    [SerializeField] private GameObject udpReceiver;

    [Header("Cart Manager")]
    [SerializeField] private CartManager cartManager;

    [Header("View Controller")]
    [SerializeField] private ViewController viewController;

    [Header("Menu Frame Content")]
    [SerializeField] private RectTransform menuContent;

    [Header("Pay Frame Content")]
    [SerializeField] private RectTransform payContent;

    [Header("Order Number TMP")]
    [SerializeField] private TextMeshProUGUI orderNumTMP;

    private int orderNumber;

    private void Start()
    {
        GoStartMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartToSelect();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoStartMenu();
        }
    }

    public void StartToSelect()
    {
        startCanvas.SetActive(false);
        selectCanvas.SetActive(true);
    }

    public void SelectToMain()
    {
        selectCanvas.SetActive(false);
        headerCanvas.SetActive(true);
        floorCanvas.SetActive(true);

        categorySphere.SetActive(true);
        udpReceiver.SetActive(true);
    }

    public void GoStartMenu()
    {
        startCanvas.SetActive(true);
        selectCanvas.SetActive(false);
        headerCanvas.SetActive(false);
        floorCanvas.SetActive(false);
        cartCanvas.SetActive(false);
        payCanvas.SetActive(false);

        foreach (GameObject sphere in menuSpheres)
        {
            sphere.SetActive(false);
        }

        categorySphere.SetActive(false);
        udpReceiver.SetActive(false);
        cartManager.Init();
        viewController.Init();
    }

    public void GoPay()
    {
        headerCanvas.SetActive(false);
        floorCanvas.SetActive(false);

        MenuGrid[] menuGrids = menuContent.GetComponentsInChildren<MenuGrid>();
        
        foreach (MenuGrid grid in menuGrids)
        {
            grid.transform.SetParent(payContent);
            grid.transform.localPosition = new Vector3(grid.transform.position.x, grid.transform.position.y, 0);
            grid.transform.localScale = Vector3.one;
            grid.transform.localEulerAngles = Vector3.zero;
        }

        foreach (GameObject sphere in menuSpheres)
        {
            sphere.SetActive(false);
        }
        categorySphere.SetActive(false);

        cartCanvas.SetActive(true);
        viewController.Init();
    }

    public void PayToMain()
    {
        headerCanvas.SetActive(true);
        floorCanvas.SetActive(true);

        categorySphere.SetActive(true);

        cartCanvas.SetActive(false);

        MenuGrid[] menuGrids = payContent.GetComponentsInChildren<MenuGrid>();

        foreach (MenuGrid grid in menuGrids)
        {
            grid.transform.SetParent(menuContent);
            grid.transform.localPosition = new Vector3(grid.transform.position.x, grid.transform.position.y, 0);
            grid.transform.localScale = Vector3.one;
            grid.transform.localEulerAngles = Vector3.zero;
        }
    }

    public void PayComplete()
    {
        orderNumber++;
        string formatted = orderNumber.ToString("D3");
        orderNumTMP.text = formatted;

        cartCanvas.SetActive(false);
        payCanvas.SetActive(true);

        Invoke("GoStartMenu", 5f);
    }
}
