using UnityEngine;
using UnityEngine.UI;

public class csShowAllEffect : MonoBehaviour
{
    [SerializeField] private Transform[] _effects;
    [SerializeField] private Text _outputOfNameEffect;
    [SerializeField] private int _numberOfStartEffect = 0;
    [Space(5)] [Header("KeyCodes")]
    [SerializeField] private KeyCode _previousEffect = KeyCode.Z;
    [SerializeField] private KeyCode _nextEffect = KeyCode.X;
    [SerializeField] private KeyCode _restart = KeyCode.C;

    private int i; 

    private void Start()
    {
        Instantiate(_effects[_numberOfStartEffect], new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log(_effects.Length);
        i = _numberOfStartEffect;
    }

    private void Update()
    {
        _outputOfNameEffect.text = i + 1 + ":" + _effects[i].name;

        if (Input.GetKeyDown(_previousEffect))
        {
            i = i > 0 ? i - 1 : _effects.Length - 1;

            Instantiate(_effects[i], new Vector3(0, 0, 0), Quaternion.identity);
        }

        if (Input.GetKeyDown(_nextEffect))
        {
            i = i < _effects.Length - 1 ? i + 1 : 0;

            Instantiate(_effects[i], new Vector3(0, 0, 0), Quaternion.identity);
        }

        if (Input.GetKeyDown(_restart))
            Instantiate(_effects[i], new Vector3(0, 0, 0), Quaternion.identity);
    }
}