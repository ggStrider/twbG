using UnityEngine;
using UnityEngine.Events;

namespace twbG.Mechanics
{
    public class OnInteractAction : MonoBehaviour
    {
        [SerializeField] private UnityEvent _action;
        [SerializeField] private bool _canInteract = true;

        public void DoAction()
        {
            if(!_canInteract) return;
            _action?.Invoke();
        }

        public void CanInteractChange(bool canChange) =>
            _canInteract = canChange;
    }
}