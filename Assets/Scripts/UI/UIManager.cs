using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameMenu _gameMenu;

        public bool IsActive => _gameMenu.gameObject.activeInHierarchy;

        private void Start()
        {
            _gameMenu.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Cancel"))
            {
                _gameMenu.gameObject.SetActive(!_gameMenu.gameObject.activeInHierarchy);
            }

            if (Input.GetButtonDown("Horizontal"))
            {
                print("Press");
            }
        }
    }
}