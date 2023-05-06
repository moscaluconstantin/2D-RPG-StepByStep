using Assets.Scripts.Data.Enums;
using System;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [Serializable]
    public class GameMenuPanelTypeValues
    {
        [SerializeField] private GameMenuPanelType _type;
        [SerializeField] private GameObject _element;

        public GameMenuPanelType Type => _type;
        public GameObject Element => _element;
    }
}
