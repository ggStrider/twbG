using UnityEngine;
using UnityEngine.Events;

namespace twbG.CollisionsTriggers
{
    public class TriggerEnter : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private EnterEvent _action;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag(_tag))
                _action.Invoke(collider.gameObject);
        }

        [System.Serializable]
        public class EnterEvent : UnityEvent<GameObject> { }
    }
}