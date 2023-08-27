using System.Collections;
using UnityEngine;

public class ScriptsActiveTimer : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] _scripts;
    [SerializeField] private float _secondsToStart;
    [SerializeField] private bool _activeSelfScriptsAfterTimer;

    private void OnEnable()
    {
        StartCoroutine(Timer());
    }

    private void OnDisable()
    {
        StopCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_secondsToStart);
        ActivateScripts(_activeSelfScriptsAfterTimer);
    }

    private void ActivateScripts(bool _isActive)
    {
        foreach (var script in _scripts)
            script.enabled = _isActive;
    }
}