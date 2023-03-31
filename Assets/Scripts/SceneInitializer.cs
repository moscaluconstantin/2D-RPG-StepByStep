using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts
{
    public class SceneInitializer : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerPrefab;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private Tilemap _tilemap;

        public PlayerMovement Player { get; private set; }

        private Vector2 _xBounds;
        private Vector2 _yBounds;

        private void Awake()
        {
            _xBounds = new Vector2(_tilemap.localBounds.min.x, _tilemap.localBounds.max.x);
            _yBounds = new Vector2(_tilemap.localBounds.min.y, _tilemap.localBounds.max.y);

            Player = CreatePlayer();
        }

        private void Start()
        {
            Player.Initialize(_xBounds, _yBounds);
            _cameraController.Follow(Player.transform);
        }

        private PlayerMovement CreatePlayer()
        {
            PlayerMovement existing = FindObjectOfType<PlayerMovement>();

            if (existing != null)
            {
                Destroy(existing.gameObject);
            }

            return Instantiate(_playerPrefab);
        }
    }
}
