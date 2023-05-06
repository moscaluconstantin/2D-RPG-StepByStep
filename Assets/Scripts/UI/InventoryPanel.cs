using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] private InventoryItem _testItem;
        [SerializeField] private Transform _slotsContainer;

        private UIInventorySlot[] _slots;

        private void Awake()
        {
            _slots = _slotsContainer.GetComponentsInChildren<UIInventorySlot>();
        }

        private void Start()
        {
            foreach (var slot in _slots)
            {
                slot.SetItem(_testItem);
            }
        }
    }
}