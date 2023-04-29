using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "InventoryItem_", menuName = "ScriptableObjects/Inventory/Inventory Item", order = 1)]
    public class InventoryItem : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;

        public int Id => _id;
        public string Name => _name;
        public Sprite Icon => _icon;
    }
}
