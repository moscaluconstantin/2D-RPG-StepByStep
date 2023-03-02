using UnityEngine;
using UnityEngine.Windows;

namespace Assets.Scripts
{
    public class CharacterAnimator : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _attackDuration = 1;
        [SerializeField] private bool _useFirstApproach = false;

        [Header("Components")]
        [SerializeField] private Animator _animator;

        public float AttackDuration => _attackDuration;

        private readonly int _xIdleHash = Animator.StringToHash("xIdle");
        private readonly int _yIdleHash = Animator.StringToHash("yIdle");
        private readonly int _xVelocityHash = Animator.StringToHash("xVelocity");
        private readonly int _yVelocityHash = Animator.StringToHash("yVelocity");
        private readonly int _isMovingHash = Animator.StringToHash("isMoving");
        private readonly int _attackHash = Animator.StringToHash("attack");

        private Vector2 _lastInput = Vector2.down;
        private bool _wasMoving = false;

        public void SetCurrentInput(Vector2 input)
        {
            if (_useFirstApproach)
            {
                FirstApproach(input);
            }
            else
            {
                SecondApproach(input);
            }

            /*float vs int demonstration
            int intVal = 0; // = some value
            float floatVal = 0;

            for (int i = 0; i < 100; i++)
            {
                intVal += 1;
                floatVal += 0.1f;
            }

            floatVal == 10.00000001*/
        }

        public void SetAttack() =>
            _animator.SetTrigger(_attackHash);

        private void FirstApproach(Vector2 input)
        {
            bool isMoving = input.magnitude > 0.1f;

            _animator.SetBool(_isMovingHash, isMoving);

            if (!isMoving)
                return;

            _animator.SetFloat(_xVelocityHash, input.x);
            _animator.SetFloat(_yVelocityHash, input.y);

            _animator.SetFloat(_xIdleHash, input.x);
            _animator.SetFloat(_yIdleHash, input.y);
        }

        private void SecondApproach(Vector2 input)
        {
            //bool isMoving = input.x > 0.1f || input.x < -0.1f || input.y > 0 || input.y < 0;
            bool isMoving = input.magnitude > 0.1f;

            /*if(_wasMoving == true && isMoving == false)
            if(_wasMoving == true && isMoving != true)*/
            if (_wasMoving && !isMoving)
            {
                _animator.SetFloat(_xIdleHash, _lastInput.x);
                _animator.SetFloat(_yIdleHash, _lastInput.y);
            }

            _animator.SetBool(_isMovingHash, isMoving);

            if (isMoving)
            {
                _animator.SetFloat(_xVelocityHash, input.x);
                _animator.SetFloat(_yVelocityHash, input.y);
            }

            _lastInput = input;
            _wasMoving = isMoving;
        }
    }
}