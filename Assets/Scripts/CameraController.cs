using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _lerpSpeed = 1;

        private Transform _target;
        private bool _follow = false;
        private Vector2 _xBounds;
        private Vector2 _yBounds;

        public void Initialize(Vector2 xBounds, Vector2 yBounds)
        {
            float ySize = Camera.main.orthographicSize;
            float xSize = ySize * Camera.main.aspect;

            _xBounds = xBounds + new Vector2(xSize, -xSize);
            _yBounds = yBounds + new Vector2(ySize, -ySize);
        }

        private void LateUpdate()
        {
            if (!_follow)
                return;

            var nextPosition = Vector3.Lerp(transform.position, _target.position, _lerpSpeed * Time.deltaTime);
            transform.position = new Vector3()
            {
                x = Mathf.Clamp(nextPosition.x, _xBounds.x, _xBounds.y),
                y = Mathf.Clamp(nextPosition.y, _yBounds.x, _yBounds.y),
                z = 0
            };
        }

        public void Follow(Transform target)
        {
            _target = target;
            _follow = true;
        }
    }
}