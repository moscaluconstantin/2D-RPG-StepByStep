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
        private string _activSceneName = "";

        public void LoadScene(string sceneName)
        {
            if (_isLoading)
                return;

            _loading = _coroutineRunner.StartCustomeCoroutine(Loading(sceneName));
        }

        private IEnumerator Loading(string sceneName)
        {
            _isLoading = true;

            yield return _screenFade.FadeIn();

            if (!string.IsNullOrEmpty(_activSceneName))
                yield return SceneManager.UnloadSceneAsync(_activSceneName);

            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            _activSceneName = sceneName;

            yield return _screenFade.FadeOut();

            _isLoading = false;
        }
    }
}