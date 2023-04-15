using Assets.Scripts.Infrastructure;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Precudural_Animations
{
    public class AnimationsManager : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _duration = 2;
        [SerializeField] private Vector3[] _endPositions;
        [SerializeField] private Vector3 _endEulearRotation;
        [SerializeField] private Vector3[] _endScales;

        [Header("Animation Curves")]
        [SerializeField] private AnimationCurve[] _positionCurves;

        [Header("Objects")]
        [SerializeField] private Transform[] _squares;

        private Vector3[] _startPositions;

        private Quaternion _startRotation;
        private Quaternion _endRotation;

        private bool _isAnimating = false;
        private bool _initialState = true;

        private void Awake()
        {
            _startPositions = new Vector3[_squares.Length];

            for (int i = 0; i < _squares.Length; i++)
            {
                _startPositions[i] = _squares[i].position;
            }

            _startRotation = Quaternion.identity;
            _endRotation = Quaternion.Euler(_endEulearRotation);
        }

        private void Update()
        {
            if (_isAnimating)
                return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isAnimating = true;

                for (int i = 0; i < _squares.Length; i++)
                {
                    if (_initialState)
                    {
                        StartCoroutine(ProceduralAnimations.Move(_squares[i], _startPositions[i], _endPositions[i], _duration, _positionCurves[i]));
                        StartCoroutine(ProceduralAnimations.Rotate(_squares[i], _startRotation, _endRotation, _duration, _positionCurves[i]));
                        StartCoroutine(ProceduralAnimations.Scale(_squares[i], Vector3.one, _endScales[i], _duration, _positionCurves[i]));
                    }
                    else
                    {
                        StartCoroutine(ProceduralAnimations.Move(_squares[i], _endPositions[i], _startPositions[i], _duration, _positionCurves[i]));
                        StartCoroutine(ProceduralAnimations.Rotate(_squares[i], _endRotation, _startRotation, _duration, _positionCurves[i]));
                        StartCoroutine(ProceduralAnimations.Scale(_squares[i], _endScales[i], Vector3.one, _duration, _positionCurves[i]));
                    }
                }

                _initialState = !_initialState;
                StartCoroutine(Wait(_duration));
            }
        }

        private IEnumerator Wait(float second)
        {
            yield return new WaitForSeconds(second);
            _isAnimating = false;
        }
    }
}