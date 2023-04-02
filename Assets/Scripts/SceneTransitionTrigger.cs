using Assets.Scripts.Infrastructure;
using UnityEngine;

namespace Assets.Scripts
{
    public class SceneTransitionTrigger : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private string _sceneName;
        [SerializeField] private string _transition_key;

        [Header("Gizmos")]
        [SerializeField] private Color _gizmosColor;
        [SerializeField, Range(0.2f, 3)] private float _xSize = 1;
        [SerializeField, Range(0.2f, 3)] private float _ySize = 1;

        [Header("Components")]
        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private SceneInitializer _playerLoader;
        [SerializeField] private Transform _placement;

        private SceneLoader _sceneLoader;
        private SaveLoad _saveLoad;
        private PlayerMovement _player;

        private void OnValidate()
        {
            _collider.size = new Vector2(_xSize, _ySize);
        }

        private void Awake()
        {
            _sceneLoader = ServiceContainer.SceneLoader;
            _saveLoad = ServiceContainer.SaveLoad;
        }

        private void Start()
        {
            _player = _playerLoader.Player;

            if (_player == null || _saveLoad.PlayerData.TransitionKey != _transition_key)
                return;

            _player.transform.position = _placement.position;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.TryGetComponent<PlayerMovement>(out var _))
                return;

            _saveLoad.PlayerData.SceneName = _sceneName;
            _saveLoad.PlayerData.TransitionKey = _transition_key;

            _sceneLoader.LoadScene(_sceneName);

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = _gizmosColor;
            Gizmos.DrawCube(transform.position, new Vector3(_collider.size.x, _collider.size.y, 0.1f));

            //Gizmos.DrawSphere(_placement.position, .3f);
        }
    }
}