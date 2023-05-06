using Assets.Scripts.Data.Enums;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Data
{
    [Serializable]
    public class GameMenuButtonTypeValues
    {
        [SerializeField] private GameMenuPanelType _type;
        [SerializeField] private Button _button;

        public GameMenuPanelType Type => _type;
        public Button Button => _button;
    }
}
