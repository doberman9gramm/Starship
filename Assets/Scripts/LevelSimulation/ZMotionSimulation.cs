using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ZMotionSimulation : MonoBehaviour
{
    [SerializeField] private float _multiplyingSpeed = 1f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(0, 0f, -LevelSpeed.GetSpeed * _multiplyingSpeed);
    }
}