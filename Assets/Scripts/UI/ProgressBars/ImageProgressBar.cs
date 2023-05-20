using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ImageProgressBar : RangedProgressBar
    {
        [SerializeField] private Image _image;

        protected override void OnFill(float fill) =>
            _image.fillAmount = fill;
    }
}