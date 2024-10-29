using System.Collections.Generic;
using UnityEngine;

using twbG.Mechanics;
using Mechanics;

namespace Player
{
    [RequireComponent(typeof(SlowMo))]
    public class PlayerSystem : MonoBehaviour
    {
        [SerializeField] private GameObject _buttonsParent;
        [SerializeField] private SlowMo _slowMo;

        [Space]
        [SerializeField] private CheckObjectsInRange _interactComponent;

        private readonly Dictionary<GravitySides, Vector2> _gravitySides = new Dictionary<GravitySides, Vector2>()
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
            _interactComponent = GetComponentInChildren<CheckObjectsInRange>();
            
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
            var range = _interactComponent.CheckRange();

            foreach (var check in range)
            {
                var interactActionComponent = check.GetComponent<OnInteractAction>();

                if (interactActionComponent != null)
                    interactActionComponent.DoAction();
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            var interact = GetComponentInChildren<CheckObjectsInRange>();
            if (interact == null)
            {
                Debug.LogWarning("There is no CheckObjectsInRange component in children");
            }
        }
#endif
    }
}
// normal gravity = -9.81