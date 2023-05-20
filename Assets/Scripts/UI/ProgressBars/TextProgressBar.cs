using Assets.Scripts.UI.ProgressBars;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class TextProgressBar : ProgressBar
    {
        [SerializeField] private TextMeshProUGUI _text;

        public override void Fill(float fill) =>
            _text.SetText(fill.ToString());
    }
}