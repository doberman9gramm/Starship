using System.Collections;
using UnityEngine;

public class ScriptsActiveTimer : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] _scripts;
    [SerializeField] private float _secondsToStart;
    [SerializeField] private OnOff _afterTime;

    private void OnEnable()
    {
        StartCoroutine(Timer());
    }

    private void OnDisable()
    {
        StopCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(_secondsToStart);

        switch (_afterTime)
        {
            case OnOff.enable:
                ActivateScripts(true);
                break;
            case OnOff.disable:
                ActivateScripts(false);
                break;
        }
    }

    private void ActivateScripts(bool _isActive)
    {
        foreach (var script in _scripts)
            script.enabled = _isActive;
    }

    enum OnOff
    {
        enable,
        disable
    }
}