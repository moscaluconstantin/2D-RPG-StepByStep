using Assets.Scripts.Constants;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] CharacterAnimator _animator;
        [SerializeField] PlayerMovement _movement;

        public bool IsAttacking => _isAttacking;

        private bool _isAttacking = false;
        private float _waitTime;

        private void Update()
        {
            if (!_isAttacking && Input.GetButtonDown(InputConstants.FIRE_1))
            {
                _isAttacking = true;
                _movement.StopMovement();
                _animator.SetAttack();
                _waitTime = _animator.AttackDuration;
                return;
            }

            _waitTime -= Time.deltaTime;

            if(_waitTime <= 0)
            {
                _isAttacking = false;
                _movement.StartMovement();
            }
        }
    }
}
