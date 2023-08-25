using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private CursorLockMode _onEnableLockMode;
    [SerializeField] private CursorLockMode _onDisableLockMode;
    [SerializeField] private CursorVisibility _onEnable;
    [SerializeField] private CursorVisibility _onDisable;

    private void OnEnable()
    {
        Cursor.lockState = _onEnableLockMode;
        ChangeCursorVisibility(_onEnable);
    }

    private void OnDisable()
    {
        Cursor.lockState = _onDisableLockMode;
        ChangeCursorVisibility(_onDisable);
    }

    private void ChangeCursorVisibility(CursorVisibility value)
    {
        switch (value)
        {
            case CursorVisibility.visibility:
                Cursor.visible = true;
                break;

            case CursorVisibility.invisibility:
                Cursor.visible = false;
                break;
        }
    }

    enum CursorVisibility
    {
        visibility,
        invisibility,
    }
}