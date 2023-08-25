using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] private float _lifeTimePerSeconds;
    [SerializeField] private Action _afterTimeUp;

    private float _endTime;

    private void OnEnable()
    {
        _endTime = Time.time + _lifeTimePerSeconds;
    }

    private void Update()
    {
        if (_endTime <= Time.time)
        {
            switch (_afterTimeUp)
            {
                case Action.DeleteObject:
                    Destroy(gameObject);
                    break;

                case Action.DisableObject:
                    gameObject.SetActive(false);
                    break;
            }
        }
    }

    private enum Action
    {
        DeleteObject,
        DisableObject,
    }
}