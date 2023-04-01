using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class GameBoostraper : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private string _startScene;

        [SerializeField] private CoroutineRunner _coroutineRunner;
        [SerializeField] private ScreenFade _screenFade;
        [SerializeField] private SceneLoader _sceneLoader;

        private SaveLoad _saveLoad;

        private void Awake()
        {
            _saveLoad = new SaveLoad();
        }

        private void Start()
        {
            ServiceContainer.SaveLoad = _saveLoad;
            ServiceContainer.CoroutineRunner = _coroutineRunner;
            ServiceContainer.ScreenFade = _screenFade;
            ServiceContainer.SceneLoader = _sceneLoader;

            if (string.IsNullOrEmpty(_saveLoad.PlayerData.SceneName))
            {
                _sceneLoader.LoadScene(_startScene);
            }
            else
            {
                _sceneLoader.LoadScene(_saveLoad.PlayerData.SceneName);
            }

        }
    }
}