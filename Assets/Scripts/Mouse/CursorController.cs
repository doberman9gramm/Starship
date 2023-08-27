using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private CursorLockMode _onEnableLockMode;
    [SerializeField] private CursorLockMode _onDisableLockMode;
    [SerializeField] private bool EnableCursorVisibility;
    [SerializeField] private bool DisableCursorVisibility;

    private void OnEnable()
    {
        Cursor.lockState = _onEnableLockMode;
        Cursor.visible = EnableCursorVisibility;
    }

    private void OnDisable()
    {
        Cursor.lockState = _onDisableLockMode;
        Cursor.visible = DisableCursorVisibility;
    }
}