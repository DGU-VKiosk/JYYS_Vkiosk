// Unity
using UnityEngine;

[DisallowMultipleComponent]
public class Window : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    private Renderer thisRenderer;
    private bool canGrab = false;

    private Quaternion initRotation;

    private int windowID;               // 윈도우 ID

    private void Awake()
    {
        thisRenderer = GetComponent<Renderer>();
        initRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        // 회전 값 고정 (부모 회전 값에 관여 받지 않음)
        transform.rotation = initRotation;
    }

    /// <summary>
    /// 윈도우 활성화 메소드
    /// </summary>
    public void ActiveCurrentWindow()
    {
        canGrab = true;
        thisRenderer.material = selectedMaterial;
    }

    /// <summary>
    /// 윈도우 비활성화 메소드
    /// </summary>
    public void DeactiveCurrentWindow()
    {
        canGrab = false;
        thisRenderer.material = defaultMaterial;
    }

    /// <summary>
    /// 그랩 가능 여부 판단 메소드
    /// </summary>
    /// <returns></returns>
    public bool CanGrab()
    {
        return canGrab;
    }

    /// <summary>
    /// 윈도우 ID 설정 메소드
    /// </summary>
    /// <param name="_ID"></param>
    public void SetWindowID(int _ID)
    {
        windowID = _ID;
    }

    /// <summary>
    /// 윈도우 ID를 가져오기 위한 메소드
    /// </summary>
    /// <returns></returns>
    public int GetWindowID()
    {
        return windowID;
    }

    public virtual void UpdateInfoToCategoryWindow(string _title) { }
    public virtual void UpdateInfoToMenuWindow(string _title, string _description) { }
}
