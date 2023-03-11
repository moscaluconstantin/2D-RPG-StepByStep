using UnityEngine;

namespace Assets.Scripts
{
    public class SceneTransitionTrigger : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Color _gizmosColor;
        [SerializeField, Range(0.2f, 3)] private float _xSize = 1;
        [SerializeField, Range(0.2f, 3)] private float _ySize = 1;
        [SerializeField] private string _sceneName;

        [Header("Components")]
        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private SceneLoader _sceneLoader;

        private void OnValidate()
        {
            _collider.size = new Vector2(_xSize, _ySize);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _sceneLoader.LoadScene(_sceneName);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = _gizmosColor;
            Gizmos.DrawCube(transform.position, new Vector3(_collider.size.x, _collider.size.y, 0.1f));
        }
    }
}