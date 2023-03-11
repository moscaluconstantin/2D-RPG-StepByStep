using Assets.Scripts.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private ScreenFade _screenFade;
        [SerializeField] private CoroutineRunner _coroutineRunner;

        private bool _isLoading = false;
        private Coroutine _loading;

        private void Start()
        {
            _screenFade.FadeOut();
        }

        public void LoadScene(string sceneName)
        {
            if (_isLoading)
                return;

            _loading = _coroutineRunner.StartCustomeCoroutine(Loading(sceneName));
        }

        public void StopoLading()
        {
            _coroutineRunner.StopCustomCoroutin(_loading);
            //_screenFade.MakeTransparent();
            _isLoading = false;
        }

        private IEnumerator Loading(string sceneName)
        {
            _isLoading = true;

            yield return _screenFade.FadeIn();
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

            _isLoading = false;
        }
    }
}