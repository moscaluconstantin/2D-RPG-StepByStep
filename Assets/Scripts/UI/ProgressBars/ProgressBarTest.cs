using UnityEngine;

namespace Assets.Scripts.UI.ProgressBars
{
    public class ProgressBarTest : MonoBehaviour
    {
        [SerializeField] private float _value;
        [SerializeField] private ProgressBar[] _prpgressBars;

        private void OnValidate()
        {
            foreach (var progressBar in _prpgressBars)
                progressBar.Fill(_value);
        }
    }
}