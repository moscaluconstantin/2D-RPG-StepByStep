using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private ScreenFade _screenFade;

        private string _sceneToLoad;
        private bool _isLoading = false;

        private void Start()
        {
            _screenFade.FadeOut();
        }

        public void LoadScene(string sceneName)
        {
            _screenFade.FadeIn();
            _sceneToLoad = sceneName;
            _isLoading = true;
        }

        private void Update()
        {
            if (!_isLoading || _screenFade.IsFading)
                return;

            SceneManager.LoadScene(_sceneToLoad, LoadSceneMode.Single);
        }
    }
}