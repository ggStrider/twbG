using UnityEngine;

namespace CheckEnvironment
{
    public class CheckIsColliderOnLayer : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;
        [SerializeField] private LayerMask _layer;

        [SerializeField] private bool _isOnLayer; 
        public bool IsOnLayer => _isOnLayer;

        private void OnTriggerStay2D(Collider2D col) 
        {
            _isOnLayer = _collider.IsTouchingLayers(_layer);
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            _isOnLayer = _collider.IsTouchingLayers(_layer);
        }
    }
}