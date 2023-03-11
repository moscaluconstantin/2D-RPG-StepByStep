using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ScreenFade : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _transitionTime = 2;

        [Header("Components")]
        [SerializeField] private CanvasGroup _fade;

        public bool IsFading => _isFading;

        private bool _isFading = false;
        private float _startAlpha;
        private float _targetAlpha;
        private float _tempT;

        private void Update()
        {
            if (!_isFading)
                return;

            _tempT += Time.deltaTime;

            float t = _tempT / _transitionTime;
            _fade.alpha = Mathf.Lerp(_startAlpha, _targetAlpha, t);

            if (_tempT > _transitionTime)
                _isFading = false;
        }

        public void FadeIn()
        {
            _startAlpha = 0;
            _targetAlpha = 1;
            _tempT = 0;
            _isFading = true;
        }

        public void FadeOut()
        {
            _startAlpha = 1;
            _targetAlpha = 0;
            _tempT = 0;
            _isFading = true;
        }
    }
}