using UnityEngine;
using Ship;

public class Fracture : MonoBehaviour
{
    //Изменен
    [Tooltip("\"Fractured\" is the object that this will break into")]
    [SerializeField] private GameObject _fractured;
    [SerializeField] private bool _fractureObjectByEnterCollider;
    [SerializeField] private AfterFracture _afterFracture;

    private void FractureObject()
    {
        if (gameObject == null)
            return;

        Instantiate(_fractured, transform.position, transform.rotation);

        switch (_afterFracture)
        {
            case AfterFracture.DeleteObject:
                Destroy(gameObject);
                break; 

            case AfterFracture.DisableObject:
                gameObject.SetActive(false);
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<HealthAndExplosion>(out HealthAndExplosion health) == false)
            return;

        health.Hit(1);

        if (_fractureObjectByEnterCollider)
            FractureObject();
    }

    private enum AfterFracture
    {
        DeleteObject,
        DisableObject,
    }
}