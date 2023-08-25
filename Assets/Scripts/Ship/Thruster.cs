using UnityEngine;

namespace Ship
{
    [RequireComponent(typeof(ParticleSystem))]
    public class Thruster : MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        private int _stopSpeed = 0;
        private int _normalSpeed = 50;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        private void FixedUpdate()
        {
            var speed = LevelSpeed.GetSpeed;

            if (speed <= _stopSpeed)
            {
                ChangeParticalState(States.stop);
                return;
            }

            if (speed >= _normalSpeed)
            {
                ChangeParticalState(States.normal);
                return;
            }

            ChangeParticalState(States.boost);
            return;
        }

        private void ChangeParticalState(States currentState)
        {
            var main = _particleSystem.main;

            switch (currentState)
            {
                case States.boost:
                    main.startLifetime = 4; //Значения подобраны исходя из визуального тестирования частиц
                    break;

                case States.normal:
                    main.startLifetime = 7;
                    break;

                case States.stop:
                    main.startLifetime = 0;
                    break;
            }
        }

        private enum States
        {
            boost,
            normal,
            stop
        }
    }
}