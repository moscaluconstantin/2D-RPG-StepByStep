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
        [SerializeField] private CharacterAnimator _animator;

        public static string Transition_key = "";

        private Vector2 _input;
        private bool _canMove = true;

        private void Update()
        {
            if (!_canMove)
                return;

            _input = new Vector2(Input.GetAxisRaw(InputConstants.AXIS_HORIZONTAL), Input.GetAxisRaw(InputConstants.AXIS_VERTICAL));
            _animator.SetCurrentInput(_input);
        }

        private void FixedUpdate()
        {
            if (!_canMove || _input.sqrMagnitude < .1f)
                return;

            var nextPosition = (Vector2)transform.position + _input.normalized * (_movementSpeed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(nextPosition);
        }

        public void StartMovement() =>
            _canMove = true;

        public void StopMovement()
        {
            _canMove = false;
            _animator.SetCurrentInput(Vector2.zero);
            _input = Vector2.zero;
        }
    }
}