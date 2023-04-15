using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public static class ProceduralAnimations
    {
        public static IEnumerator Move(Transform target, Vector3 from, Vector3 to, float duration, AnimationCurve curve)
        {
            float time = 0;

            while (time < duration)
            {
                float t = time / duration;
                float curveT = curve.Evaluate(t);

                target.position = Vector3.Lerp(from, to, curveT);

                time += Time.deltaTime;

                yield return null;
            }

            target.position = to;
        }

        public static IEnumerator Rotate(Transform target, Quaternion from, Quaternion to, float duration, AnimationCurve curve)
        {
            float time = 0;

            while (time < duration)
            {
                float t = time / duration;
                float curveT = curve.Evaluate(t);

                target.rotation = Quaternion.Lerp(from, to, curveT);

                time += Time.deltaTime;

                yield return null;
            }

            target.rotation = to;
        }

        public static IEnumerator Scale(Transform target, Vector3 from, Vector3 to, float duration, AnimationCurve curve)
        {
            float time = 0;

            while (time < duration)
            {
                float t = time / duration;
                float curveT = curve.Evaluate(t);

                target.localScale = Vector3.Lerp(from, to, curveT);

                time += Time.deltaTime;

                yield return null;
            }

            target.localScale = to;
        }
    }
}
