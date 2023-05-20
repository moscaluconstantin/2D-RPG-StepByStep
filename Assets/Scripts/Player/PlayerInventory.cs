using Assets.Scripts.Data;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private InventorySlot[] _items;

        //public IEnumerable<InventoryItem> Items => _items.Select(x => x.Item);

        private void Awake()
        {
            RemoveDuplicates();
        }

        public InventoryItem[] GetItems()
        {
            InventoryItem[] items = new InventoryItem[_items.Length];

            for (int i = 0; i < _items.Length; i++)
                items[i] = _items[i].Item;

            return items;
        }

        public int Count(InventoryItem item)
        {
            if (item == null)
                return 0;

            foreach (var slot in _items)
            {
                if (slot.Item != null && slot.Item.Id == item.Id)
                    return slot.Count;
            }

            return 0;
        }

        private void RemoveDuplicates()
        {
            for (int i = 0; i < _items.Length - 1; i++)
            {
                if (_items[i].Item == null)
                    continue;

                for (int j = i + 1; j < _items.Length; j++)
                {
                    if (_items[j].Item == null)
                        continue;

                    if (_items[j].Item.Id == _items[i].Item.Id)
                    {
                        _items[i].Count += _items[j].Count;

                        _items[j].Item = null;
                        _items[j].Count = 0;
                    }
                }
            }
        }
    }
}
