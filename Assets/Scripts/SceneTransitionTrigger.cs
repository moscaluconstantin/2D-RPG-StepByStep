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
        [SerializeField] private PlayerLoader _playerLoader;
        [SerializeField] private Transform _placement;

        private SceneLoader _sceneLoader;

        private void OnValidate()
        {
            _collider.size = new Vector2(_xSize, _ySize);
        }

        private void Awake()
        {
            _sceneLoader = ServiceContainer.SceneLoader;
        }

        private void Start()
        {
            var player = _playerLoader.Player;

            if (player == null || PlayerMovement.Transition_key != _transition_key)
                return;

            player.transform.position = _placement.position;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerMovement.Transition_key = _transition_key;
            _sceneLoader.LoadScene(_sceneName);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = _gizmosColor;
            Gizmos.DrawCube(transform.position, new Vector3(_collider.size.x, _collider.size.y, 0.1f));
        }
    }
}