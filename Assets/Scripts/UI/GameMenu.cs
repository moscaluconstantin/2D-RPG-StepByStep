using Assets.Scripts.Data;
using Assets.Scripts.Data.Enums;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class GameMenu : MonoBehaviour
    {
        [SerializeField] private GameMenuPanelType _initialPanelType;

        [Header("Components")]
        [SerializeField] private GameMenuButtonTypeValues[] _panelButtons;
        [SerializeField] private GameMenuPanelTypeValues[] _panels;

        private void OnEnable()
        {
            OpenPanel(_initialPanelType);
        }


        public void OpenStats()
        {
            OpenPanel(GameMenuPanelType.Stats);
        }

        public void OpenInventory()
        {
            OpenPanel(GameMenuPanelType.Inventory);
        }

        public void Save()
        {
            print("Save");
        }

        public void Close()
        {
            print("Close");
        }

        public void Quit()
        {
            Application.Quit();
        }

        private void OpenPanel(GameMenuPanelType panelType)
        {
            for (int i = 0; i < _panelButtons.Length; i++)
                _panelButtons[i].Button.interactable = _panelButtons[i].Type != panelType;

            for (int i = 0; i < _panels.Length; i++)
                _panels[i].Element.SetActive(_panels[i].Type == panelType);
        }
    }
}