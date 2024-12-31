using UnityEngine;
using DG.Tweening;
using Interact.Actions.Strategies.Lever.Tools;

namespace Interact.Actions.Strategies.Lever
{
    public class LeverMoveObject : MonoBehaviour, ILeverAction
    {
        [SerializeField] private Transform _objectToMove;
        
        [SerializeField] private float _timeToMove = 1f;
        
        [SerializeField] private Vector3 _endPosition;
        [SerializeField] private Vector3 _startPosition;

        public void Activated()
        {
            _objectToMove.DOMove(_endPosition, _timeToMove)
                .SetEase(Ease.Linear);
        }

        public void Deactivated()
        {
            _objectToMove.DOMove(_startPosition, _timeToMove)
                .SetEase(Ease.Linear);
        }
        
        #if UNITY_EDITOR

        private void OnValidate()
        {
            if (_objectToMove != _lastObjectToMove)
            {
                Debug.Log("DIFFERENT");
                ObjectToMoveChanged();
            }
        }
        
        private Transform _lastObjectToMove;

        public void ObjectToMoveChanged()
        {
            Debug.Log(_lastObjectToMove.gameObject.name);
            if (_lastObjectToMove != null)
            {
                var obj = _lastObjectToMove.GetComponent<SendPositionToLever>();
                DestroyImmediate(obj);
            }
            _lastObjectToMove = _objectToMove;

            var sendPositionToLever = _objectToMove.GetComponent<SendPositionToLever>();
            if(sendPositionToLever == null) 
                _objectToMove.gameObject.AddComponent<SendPositionToLever>();
        }
        
        public void _SetStartPosition()
        {
            _startPosition = _objectToMove.position;
        }
        
        public void _SetEndPosition()
        {
            _startPosition = _objectToMove.position;
        }
        #endif
    }
}