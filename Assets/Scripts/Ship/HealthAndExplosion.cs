using UnityEngine;
using UnityEngine.Events;

namespace Ship
{
    public class HealthAndExplosion : MonoBehaviour
    {
        public UnityEvent GameEnd;

        [SerializeField] private uint _startHp;
        [SerializeField] private GameObject _shipBody;
        [SerializeField] private GameObject _explosionPrefab;

        public void Hit(uint hp)
        {
            _startHp -= hp;
            if (_startHp == 0)
                Explosion();
        }

        private void Explosion()
        {
            Time.timeScale = 0.8f;
            foreach (Transform shipPart in _shipBody.GetComponentInChildren<Transform>())
            {
                shipPart.gameObject.AddComponent<Rigidbody>();
                shipPart.gameObject.AddComponent<ZMotionSimulation>();
                shipPart.parent = null;
            }
            GameObject explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            explosion.gameObject.AddComponent<LifeTime>();
            GameEnd?.Invoke();
            Destroy(gameObject);
        }
    }
}