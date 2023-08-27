using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationValue;

    private void FixedUpdate() => transform.Rotate(_rotationValue);
}