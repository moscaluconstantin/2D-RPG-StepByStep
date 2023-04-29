using Assets.Scripts.ScriptableObjects;
using System;

namespace Assets.Scripts.Data
{
    [Serializable]
    public class InventorySlot
    {
        public InventoryItem Item;
        public int Count;
    }
}
