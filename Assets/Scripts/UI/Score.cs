using UnityEngine;
using TMPro;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Score : MonoBehaviour
    {
        [SerializeField] private float _multiplicationScore = 0.1f;

        private ulong _score = 0;
        private TextMeshProUGUI _textMeshPro;

        public ulong GetScore => _score;

        private void Awake()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        private void FixedUpdate()
        {
            _score += (ulong)(LevelSpeed.GetSpeed * _multiplicationScore);
            _textMeshPro.text = _score.ToString();
        }
    }
}