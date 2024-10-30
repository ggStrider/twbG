using UnityEngine;

using Mechanics;
using Interact;
using CheckEnvironment;

using System.Collections.Generic;

namespace Player
{
    [RequireComponent(typeof(SlowMo))]
    public class PlayerSystem : MonoBehaviour
    {
        [SerializeField] private GameObject _buttonsParent;
        [SerializeField] private SlowMo _slowMo;

        [Space]
        [SerializeField] private GetObjectsInRange _interactComponent;

        private readonly Dictionary<GravitySides, Vector2> _gravitySides = new Dictionary<GravitySides, Vector2>
        {
            [GravitySides.Down] = new Vector2(0, -DEFAULT_GRAVITY),
            [GravitySides.Up] = new Vector2(0, DEFAULT_GRAVITY),
            [GravitySides.Left] = new Vector2(-DEFAULT_GRAVITY, 0),
            [GravitySides.Right] = new Vector2(DEFAULT_GRAVITY, 0)
        };
        
        private enum GravitySides
        {
            Down,
            Up,
            Left,
            Right
        };
        
        private const float DEFAULT_GRAVITY = 9.81f;

        private void Awake()
        {
            _slowMo = GetComponent<SlowMo>();
            _interactComponent = GetComponentInChildren<GetObjectsInRange>();
            
            Physics2D.gravity = _gravitySides[GravitySides.Down];
        }

        #region Gravity
        
        public void OnChangingGravity(bool isPressing)
        {
            _slowMo.ToggleSlowMo(isPressing);
            _buttonsParent.SetActive(isPressing);
        }

        public void SetGravityDown() => SetGravitySide(GravitySides.Down);
        public void SetGravityUp() => SetGravitySide(GravitySides.Up);
        public void SetGravityRight() => SetGravitySide(GravitySides.Right);
        public void SetGravityLeft() => SetGravitySide(GravitySides.Left);

        private void SetGravitySide(GravitySides gravitySide)
        {
            Physics2D.gravity = _gravitySides[gravitySide];
            OnChangingGravity(false);
        }
        
        #endregion

        public void Interact()
        {
            var objectsInRange = _interactComponent.GetObjects();

            foreach (var currentObject in objectsInRange)
            {
                var interactComponent = currentObject.GetComponent<IInteract>();
                interactComponent?.Interact();
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            var interact = GetComponentInChildren<GetObjectsInRange>();
            if (interact == null)
            {
                Debug.LogWarning("There is no CheckObjectsInRange component in children");
            }
        }
#endif
    }
}
// normal gravity = -9.81