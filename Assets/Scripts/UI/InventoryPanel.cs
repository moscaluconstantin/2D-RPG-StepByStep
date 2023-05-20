using Assets.Scripts.Infrastructure;
using Assets.Scripts.Player;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] private InventoryItem _testItem;
        [SerializeField] private Transform _slotsContainer;

        private UIInventorySlot[] _slots;
        private PlayerInventory _inventory;

        private void Awake()
        {
            _slots = _slotsContainer.GetComponentsInChildren<UIInventorySlot>();
            _inventory = ServiceContainer.PlayerInventory;
        }

        private void OnEnable()
        {
            InventoryItem[] items = _inventory.GetItems();

            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                int count = _inventory.Count(items[i]);

                _slots[i].SetItem(item, count);
            }

        }
    }
}