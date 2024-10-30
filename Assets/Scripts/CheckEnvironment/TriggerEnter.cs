using UnityEngine;
using UnityEngine.Events;

using System;

namespace CheckEnvironment
{
    public class TriggerEnter : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private EnterEvent _action;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_tag == string.Empty || !other.CompareTag(_tag)) return;
            _action.Invoke(other.gameObject);
        }

        [Serializable]
        public class EnterEvent : UnityEvent<GameObject> { }
    }
}