using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ScreenFade : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _transitionTime = 2;

        [Header("Components")]
        [SerializeField] private CanvasGroup _fade;
        [SerializeField] private CoroutineRunner _coroutineRunner;

        public bool IsFading => _isFading;

        private bool _isFading = false;

        public Coroutine FadeIn()
        {
            if (_isFading)
                return null;

            return _coroutineRunner.StartCustomeCoroutine(Fade(0, 1));
        }

        public Coroutine FadeOut()
        {
            if (_isFading)
                return null;

            return _coroutineRunner.StartCustomeCoroutine(Fade(1, 0));
        }

        private IEnumerator Fade(float from, float to)
        {
            _isFading = true;
            float passedTime = 0;

            while (passedTime <= _transitionTime)
            {
                passedTime += Time.deltaTime;
                float t = passedTime / _transitionTime;
                _fade.alpha = Mathf.Lerp(from, to, t);

                yield return null;
            }

            _isFading = false;
        }
    }
}