using Assets.Scripts.Constants;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Range(1, 10)] private float _movementSpeed = 4;

        [Header("Components")]
        [SerializeField] private Rigidbody2D _rigidbody;

        private Vector2 _input;

        private void Update()
        {
            _input = new Vector2(Input.GetAxisRaw(InputConstants.AXIS_HORIZONTAL), Input.GetAxisRaw(InputConstants.AXIS_VERTICAL));
        }

        private void FixedUpdate()
        {
            if (_input.sqrMagnitude < .1f)
                return;

            var nextPosition = (Vector2)transform.position + _input * (_movementSpeed * Time.deltaTime);
            _rigidbody.MovePosition(nextPosition);
        }
    }
}