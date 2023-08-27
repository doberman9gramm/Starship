using UnityEngine;
using System.Collections;
using TMPro;


namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI), typeof(AudioSource))]
    public class UIEndScore : MonoBehaviour
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

        private void OnEnable()
        {
            StartCoroutine(GameEndScoreEffect());
        }

        private void OnDisable()
        {
            StopCoroutine(GameEndScoreEffect());
        }

        private IEnumerator GameEndScoreEffect()
        {
            ulong score = 0;

            while (score <= _score.GetScore)
            {
                yield return new WaitForSeconds(_secondsStep);
                score += _score.GetScore / _dividerPercent;
                _textMeshPro.text = ("Score " + score);
            }
            _textMeshPro.text = ("Score " + _score.GetScore);
            _audioSource.enabled = false;
        }
    }
}