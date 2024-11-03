using System.Linq;
using UnityEngine;
using Interact.Actions.Strategies.Lever;

namespace Interact.Actions
{
    public class InteractLever : MonoBehaviour, IInteract
    {
        [SerializeField] private bool _isActivated;
        private ILeverAction _leverAction;
        
        [SerializeField] private LeverTypes _leverType;
        private enum LeverTypes
        {
            Log,
            ChangeAnotherObjectPosition
        }

        private void Start()
        {
            _leverAction = GetComponent<ILeverAction>();
        }
        
        public void Interact()
        {
            _isActivated = !_isActivated;

            if (_isActivated) _leverAction?.Activated();
            else _leverAction?.Deactivated();
        }
        
#if UNITY_EDITOR
        public void _ResetLeverType()
        {
            var actions = GetComponents<MonoBehaviour>().OfType<ILeverAction>();
            foreach (var action in actions)
            {
                DestroyImmediate((MonoBehaviour)action);
            }

            switch (_leverType)
            {
                case LeverTypes.Log:
                    gameObject.AddComponent<LeverLog>();
                    break;
                
                case LeverTypes.ChangeAnotherObjectPosition:
                    gameObject.AddComponent<LeverMoveObject>();
                    break;
                
                default:
                    Debug.LogWarning("Something went wrong!");
                    break;
            }
        }
#endif
    }
}
