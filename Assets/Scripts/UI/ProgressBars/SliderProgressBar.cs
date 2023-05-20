using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class SliderProgressBar : RangedProgressBar
    {
        [SerializeField] private Slider _slider;

        protected override void OnFill(float fill) =>
            _slider.value = fill;
    }
}