// Unity
using UnityEngine;

using TMPro;

[DisallowMultipleComponent]
public class Window : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    private Renderer thisRenderer;
    private bool canGrab = false;

    private Quaternion initRotation;
    private int windowID;

    private void Awake()
    {
        thisRenderer = GetComponent<Renderer>();
        initRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        transform.rotation = initRotation;
    }

    public void SetCurrentWindow()
    {
        canGrab = true;
        thisRenderer.material = selectedMaterial;
    }

    public void CancelCurrentWindow()
    {
        canGrab = false;
        thisRenderer.material = defaultMaterial;
    }

    public bool CanGrab()
    {
        return canGrab;
    }

    public void SetWindowID(int _ID)
    {
        windowID = _ID;
    }

    public int GetWindowID()
    {
        return windowID;
    }

    public virtual void UpdateInfoToCategoryWindow(string _title) { }
    public virtual void UpdateInfoToMenuWindow(string _title, string _description) { }
}
