using Assets.Scripts.Constants;
using Assets.Scripts.Infrastructure;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Range(1, 10)] private float _movementSpeed = 4;
        [SerializeField] private Vector2 _xBoundsOffset;
        [SerializeField] private Vector2 _yBoundsOffset;

        [Header("Components")]
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private CharacterAnimator _animator;

        public static string Transition_key = "";

        private ScreenFade _screenFade;
        private PlayerAttack _attack;

        private bool CanMove => !_screenFade.IsFading && !_attack.IsAttacking;
        private Vector2 _input;
        private Vector2 _xBounds;
        private Vector2 _yBounds;

        //private bool CanMove = true;

        private void Awake()
        {
            _screenFade = ServiceContainer.ScreenFade;
            _attack = GetComponent<PlayerAttack>();
        }

        public void Initialize(Vector2 xBounds, Vector2 yBounds)
        {
            _xBounds = xBounds + _xBoundsOffset;
            _yBounds = yBounds + _yBoundsOffset;
        }

        private void Update()
        {
            if (!CanMove)
            {
                _animator.SetCurrentInput(Vector2.zero);
                _input = Vector2.zero;
                return;
            }

            _input = new Vector2(Input.GetAxisRaw(InputConstants.AXIS_HORIZONTAL), Input.GetAxisRaw(InputConstants.AXIS_VERTICAL));
            _animator.SetCurrentInput(_input);
        }

        private void FixedUpdate()
        {
            if (!CanMove || _input.sqrMagnitude < .1f)
                return;

            var nextPosition = GetNextPosition();
            _rigidbody.MovePosition(nextPosition);
        }

        private Vector2 GetNextPosition()
        {
            var deltaMovement = _input.normalized * (_movementSpeed * Time.fixedDeltaTime);

            return new Vector2()
            {
                x = Mathf.Clamp(transform.position.x + deltaMovement.x, _xBounds.x, _xBounds.y),
                y = Mathf.Clamp(transform.position.y + deltaMovement.y, _yBounds.x, _yBounds.y),
            };
        }

        //public void StartMovement() => 
        //    _canMove = true;

        //public void StopMovement()
        //{
        //    _canMove = false;
        //    _animator.SetCurrentInput(Vector2.zero);
        //    _input = Vector2.zero;
        //}
    }
}