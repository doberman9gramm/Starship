using UnityEngine;

namespace Ship
{
    public class MovementByPosition : MonoBehaviour
    {
        [SerializeField] private PositionGroup _positions;
        [SerializeField, Header("Move Towards")] private float _maxDistanceDelta;

        private Transform[] _transformPositions;
        private int _maxPostion;
        private int _startPosition = 1;
        private int _currentPosition;
        private Vector3 _targetPosition;

        private void Start()
        {
            _transformPositions = _positions.Transforms;
            _maxPostion = _transformPositions.Length;
            gameObject.transform.position = _transformPositions[_startPosition].position;
            _currentPosition = _startPosition;
        }

        private void Update()
        {
            if (IsGamePaused)
                return;

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                TryIncreasePositionValue();
                _targetPosition = GetNewTargetPosition;
                return;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                TryReducePositionValue();
                _targetPosition = GetNewTargetPosition;
                return;
            }
        }

        private void FixedUpdate()
        {
            if (IsGamePaused)
                return;

            ChangePosition();
        }

        private bool IsGamePaused => Time.timeScale == 0;

        private Vector3 GetNewTargetPosition => _transformPositions[_currentPosition].position;

        private void TryIncreasePositionValue()
        {
            if (_maxPostion > _currentPosition + 1)
                _currentPosition += 1;
        }

        private void TryReducePositionValue()
        {
            if (0 <= _currentPosition - 1)
                _currentPosition -= 1;
        }

        private void ChangePosition()
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _maxDistanceDelta);
        }
    }
}