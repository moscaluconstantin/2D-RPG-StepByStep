using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Coroutines
{
    public class CoroutineTester : MonoBehaviour
    {
        public bool _continue = false;
        public bool _pause = true;
        private WaitForSeconds _waitSomeTime;
        private Coroutine _coroutine;

        private void Awake()
        {
            _waitSomeTime = new WaitForSeconds(3);
        }

        private void Start()
        {
            //StartCoroutine("DoSomething");
            //_coroutine = StartCoroutine(DoSomething());
            _coroutine = StartCoroutine(AnotherCoroutin());
            StartCoroutine(WaitAnotherToEnd());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StopCoroutine(_coroutine);
            }
        }

        private IEnumerator AnotherCoroutin()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(1);
                print("Another second passed.");
            }
        }

        private IEnumerator DoSomething()
        {
            print("Start");

            //yield return _waitSomeTime;

            //yield return new WaitUntil(CanContinue);
            //yield return new WaitUntil(() =>
            //{
            //    //skjdf
            //    //sdf
            //    return _continue;
            //});
            //yield return new WaitUntil(() => _continue);

            yield return new WaitWhile(() => _pause);

            print("Finish");
        }

        private IEnumerator WaitAnotherToEnd()
        {
            print("Start");

            yield return _coroutine;

            print("Finish");
        }

        private bool CanContinue()
        {
            return _continue;
        }
    }
}