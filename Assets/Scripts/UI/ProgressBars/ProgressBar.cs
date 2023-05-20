using UnityEngine;

namespace Assets.Scripts.UI.ProgressBars
{
    public abstract class ProgressBar : MonoBehaviour
    {
        public abstract void Fill(float fill);
    }
}
