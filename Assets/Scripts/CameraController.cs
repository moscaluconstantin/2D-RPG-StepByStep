using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _lerpSpeed = 1;

        private Transform _target;
        private bool _follow = false;

        private void LateUpdate()
        {
            if (!_follow)
                return;

            var nextPosition = Vector3.Lerp(transform.position, _target.position, _lerpSpeed * Time.deltaTime);
            transform.position = nextPosition;
        }

        public void Follow(Transform target)
        {
            _target = target;
            _follow = true;
        }
    }
}