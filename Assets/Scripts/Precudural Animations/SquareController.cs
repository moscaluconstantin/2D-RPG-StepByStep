using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class SquareController : MonoBehaviour
    {
        [SerializeField] private float _duration = 1;
        [SerializeField] private Vector3 _deltaRotation;
        [SerializeField] private LayerMask _groundLayer;

        private bool _onGround = true;
        //private float _velocity = 0;
        //private float _targetValue;

        private void Start()
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.down, 10, _groundLayer);

            if(hit != null)
            {
                transform.position = hit.point;
            }
            else
            {
                print("Can't find ground");
            }

        }

        void Update()
        {
            //Version 1
            if (_onGround && Input.GetKeyDown(KeyCode.Space))
                print("jump");
                //StartCoroutine(Rotation());


            /*//Version 2
            if (Input.GetKeyDown(KeyCode.Space))
                _targetValue = transform.rotation.eulerAngles.z - 90;

            float newAngleY = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.z, _targetValue, ref _velocity, _duration);
            transform.rotation = Quaternion.Euler(Vector3.forward * newAngleY);*/
        }

        private IEnumerator Rotation()
        {
            float timer = 0;
            var startValue = transform.rotation;
            var endValue = Quaternion.Euler(startValue.eulerAngles + _deltaRotation);

            _onGround = false;

            while (timer < _duration)
            {
                timer += Time.deltaTime;
                float t = timer / _duration;

                transform.rotation = Quaternion.Lerp(startValue, endValue, t);

                yield return null;
            }

            transform.rotation = endValue;
            _onGround = true;
        }
    }
}