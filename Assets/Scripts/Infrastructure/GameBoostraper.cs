using Assets.Scripts.Player;
using Assets.Scripts.UI;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class GameBoostraper : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private string _uiScene;

        [SerializeField] private CoroutineRunner _coroutineRunner;
        [SerializeField] private ScreenFade _screenFade;
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private PlayerInventory _playerInventory;

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
            ServiceContainer.PlayerInventory = _playerInventory;

            LoadScenes();
        }

        private void LoadScenes() => 
            _coroutineRunner.StartCustomeCoroutine(ScenesLoading());

        private IEnumerator ScenesLoading()
        {
            //start loading screen

            yield return _sceneLoader.LoadSceneWithoutTracking(_uiScene);

            //finish loading screen

            yield return _sceneLoader.LoadScene(_saveLoad.PlayerData.SceneName);
        }
    }
}