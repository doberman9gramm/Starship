using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SkyboxRotation : MonoBehaviour
{
    [SerializeField] private Material _skybox;
    [SerializeField] private float _addValuePerFixedUpdate = 0.02f;
    
    private float _startRotationValue = 0f;

    private void FixedUpdate()
    {
        if (Time.timeScale != 0)
            _skybox.SetFloat("_Rotation", _startRotationValue += _addValuePerFixedUpdate);
    }
}