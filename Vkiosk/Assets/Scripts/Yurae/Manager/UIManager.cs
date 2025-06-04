// Unity
using UnityEngine;

[DisallowMultipleComponent]
public class UIManager : MonoBehaviour
{
    [Header("Start Menu Canvas")]
    [SerializeField] private GameObject startCanvas;

    [Header("Select Order Canvas")]
    [SerializeField] private GameObject selectCanvas;

    [Header("Common Header Canvas")]
    [SerializeField] private GameObject headerCanvas;

    [Header("Menw Sphere")]
    [SerializeField] private GameObject[] menuSpheres;

    [Header("Category Sphere")]
    [SerializeField] private GameObject categorySphere;

    [Header("UDP Receiver")]
    [SerializeField] private GameObject udpReceiver;

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

        categorySphere.SetActive(true);
        udpReceiver.SetActive(true);
    }

    public void GoStartMenu()
    {
        startCanvas.SetActive(true);
        selectCanvas.SetActive(false);
        headerCanvas.SetActive(false);

        foreach (GameObject sphere in menuSpheres)
        {
            sphere.SetActive(false);
        }

        categorySphere.SetActive(false);
        udpReceiver.SetActive(false);
    }
}
