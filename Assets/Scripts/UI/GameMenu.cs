using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class GameMenu : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons;

        private void Awake()
        {
            _buttons[0].onClick.RemoveAllListeners();
            _buttons[0].onClick.AddListener(Click4);
        }

        public void Click1()
        {
            print("Click 1");
        }
        
        public void Click2()
        {
            print("Click 2");
        }

        public void Click3()
        {
            print("Click 3");
        }

        private void Click4()
        {
            print("Click private");
        }
    }
}