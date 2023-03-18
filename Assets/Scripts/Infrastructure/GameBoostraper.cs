using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class GameBoostraper : MonoBehaviour
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;
        [SerializeField] private ScreenFade _screenFade;
        [SerializeField] private SceneLoader _sceneLoader;

        private void Start()
        {
            ServiceContainer.SceneLoader = _sceneLoader;

            _sceneLoader.LoadScene("TestScene");
        }
    }
}