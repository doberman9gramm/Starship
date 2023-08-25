using UnityEngine;

public class TransformRotation : MonoBehaviour
{
    [SerializeField] private float _xSpeed, _ySpeed, _zSpeed;

    private void FixedUpdate() => transform.Rotate(_xSpeed, _ySpeed, _zSpeed);
}