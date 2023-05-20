using Assets.Scripts.UI.ProgressBars;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public abstract class RangedProgressBar : ProgressBar
    {
        [SerializeField][Range(0, 1)] private float _normalFill;
        [SerializeField] private float _fill;
        [SerializeField] private bool _userNormalFill;

        [Header("Settings")]
        [SerializeField] protected float _minValue = 0;
        [SerializeField] protected float _maxValue = 1;

        private void OnValidate()
        {
            if (_userNormalFill)
            {
                OnFill(_normalFill);
            }
            else
            {
                Fill(_fill);
            }
        }

        public void Initialize(float minValue, float maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public override void Fill(float fill)
        {
            _normalFill = Mathf.InverseLerp(_minValue, _maxValue, fill);
            _fill = fill;

            OnFill(_normalFill);
        }

        protected abstract void OnFill(float fill);
    }
}