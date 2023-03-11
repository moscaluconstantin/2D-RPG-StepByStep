using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CoroutineRunner : MonoBehaviour
    {

        public Coroutine StartCustomeCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }

        public void StopCustomCoroutin(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}