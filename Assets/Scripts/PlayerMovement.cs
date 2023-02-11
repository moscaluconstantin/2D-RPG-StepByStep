using Assets.Scripts.Constants;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Range(0, 100)] private float _movementSpeed = 2;

        [Header("Components")]
        [SerializeField] private Rigidbody2D _rigidbody;

        private Vector2 _newPosition;



        private void Update()
        {
            var input = new Vector2(Input.GetAxisRaw(InputConstants.AXIS_HORIZONTAL), Input.GetAxisRaw(InputConstants.AXIS_VERTICAL));
            _newPosition = (Vector2)transform.position + input * (_movementSpeed * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_newPosition);
        }
    }
}