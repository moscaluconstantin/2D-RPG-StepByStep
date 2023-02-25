using UnityEngine;

namespace Assets.Scripts
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private Vector2 _lastInput = Vector2.down;
        private bool _wasMoving = false;

        public void SetCurrentInput(Vector2 input)
        {
            //bool isMoving = input.x > 0.1f || input.x < -0.1f || input.y > 0 || input.y < 0;

            bool isMoving = input.magnitude > 0.1f;

            //if(_wasMoving == true && isMoving == false)
            //if(_wasMoving == true && isMoving != true)
            if(_wasMoving && !isMoving)
            {
                _animator.SetFloat("xIdle", _lastInput.x);
                _animator.SetFloat("yIdle", _lastInput.y);
            }

            _animator.SetBool("isMoving", isMoving);

            _animator.SetFloat("xVelocity", input.x);
            _animator.SetFloat("yVelocity", input.y);

            _lastInput = input;
            _wasMoving = isMoving;

            //int intVal = 0; // = some value
            //float floatVal = 0;

            //for (int i = 0; i < 100; i++)
            //{
            //    intVal += 1;
            //    floatVal += 0.1f;
            //}

            //floatVal == 10.00000001
        }
    }
}