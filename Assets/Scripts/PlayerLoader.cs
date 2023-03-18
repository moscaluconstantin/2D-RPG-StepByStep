using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerLoader : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerPrefab;

        public PlayerMovement Player { get; private set; }

        private void Awake()
        {
            PlayerMovement existing = FindObjectOfType<PlayerMovement>();

            if (existing != null)
            {
                Destroy(existing.gameObject);
            }

            Player = Instantiate(_playerPrefab);
        }
    }
}
