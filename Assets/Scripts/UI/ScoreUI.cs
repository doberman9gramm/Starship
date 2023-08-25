using UnityEngine;
using TMPro;
using System.Collections;


namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI), typeof(AudioSource))]
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private float _secondsStep;
        [SerializeField] private Score _score;

        private AudioSource _audioSource;
        private TextMeshProUGUI _textMeshPro;
        private ulong _dividerPercent = 100;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        private IEnumerator Start()
        {
            ulong score = 0;

            while (score <= _score.GetScore)
            {
                score += _score.GetScore/ _dividerPercent;
                _textMeshPro.text = ("Score " + score);

                yield return new WaitForSeconds(_secondsStep);
            }
            _textMeshPro.text = ("Score " + _score.GetScore);
            _audioSource.enabled = false;
        }
    }
}