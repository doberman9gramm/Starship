using UnityEngine;

public class Pulsation : MonoBehaviour
{
    [SerializeField] private float _step;
    [SerializeField] private float _minValue;
    [SerializeField] private float _maxValue;

    private bool _isIncrease = true;

    private void FixedUpdate()
    {
        var a = _step / 100f;

        if (_isIncrease)
        {
            transform.localScale += new Vector3(a, a, a);

            if (transform.localScale.x > _maxValue)
                _isIncrease = false;
            return;
        }
        transform.localScale -= new Vector3(a, a, a);

        if (transform.localScale.x < _minValue)
            _isIncrease = true;
    }
}