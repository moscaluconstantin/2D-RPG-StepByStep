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

        private void Start()
        {
            ServiceContainer.CoroutineRunner = _coroutineRunner;
            ServiceContainer.ScreenFade = _screenFade;
            ServiceContainer.SceneLoader = _sceneLoader;

            _sceneLoader.LoadScene(_startScene);
        }
    }
}