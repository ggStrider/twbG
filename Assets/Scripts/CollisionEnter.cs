using UnityEngine;
using UnityEngine.Events;

namespace twbG.CollisionsTriggers
{
    public class CollisionEnter : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private EnterEvent _action;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(_tag))
                _action.Invoke(collision.gameObject);
        }

        [System.Serializable]
        public class EnterEvent : UnityEvent<GameObject> { }
    }
}