using Assets.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class UIInventorySlot : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _counter;
        [SerializeField] private GameObject _container;

        private Button _button;
        private InventoryItem _item;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClicked);
        }

        public void SetItem(InventoryItem item)
        {
            _item = item;

            RefreshSlot();
            Activate();
        }

        public void Activate() => 
            SetState(true);

        public void Deactivate() => 
            SetState(false);

        private void OnClicked()
        {
            Deactivate();
        }

        private void SetState(bool newState)
        {
            _container.SetActive(newState);
            _button.enabled = newState;
        }

        private void RefreshSlot()
        {
            _icon.sprite = _item.Icon;
            _counter.SetText("0");
        }
    }
}