using UnityEngine;
using UnityEngine.Events;
using System.Collections;

using twbG.Mechanics;

namespace twbG.PlayerSystemComponents
{
    public class PlayerSystem : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        [Space]
        [SerializeField] private float _delayBetweenChoosing;
        private bool _canChoose = true;

        [SerializeField] private float _slowMoEffect;
        [SerializeField] private UnityEvent _isPressingChooseSide;
        [SerializeField] private UnityEvent _unpressChooseSide;

        [Space]
        [SerializeField] private CheckObjectsInRange _interactComponent;

        private byte _normalTimeScale = 1;
        private float _normalFixedTime = 0.02f;
        private bool _isSlowMo;

        private const byte GravityDown = 0;
        private const byte GravityUp = 1;
        private const byte GravityRight = 2;
        private const byte GravityLeft = 3;

        private void Awake() =>
            Physics2D.gravity = new Vector2(0, -9.81f);

        public void ChangeGravity(bool isPressing)
        {
            if (!_canChoose) return;

            if (isPressing)
            {
                _isPressingChooseSide?.Invoke();
            }
            else
            {
                _unpressChooseSide?.Invoke();
            }
        }

        private IEnumerator CanUseDelay(float delay)
        {
            _canChoose = false;

            yield return new WaitForSeconds(delay);
            _canChoose = true;
        }


        public void SetGravitySide(int mode)
        {
            var s_gravity = 9.81f;

            // Down
            if (mode == GravityDown)
            {
                Physics2D.gravity = new Vector2(0, -s_gravity);
                print("down");
            }
            // Up
            else if (mode == GravityUp)
            {
                Physics2D.gravity = new Vector2(0, s_gravity);
                print("up");
            }
            // Right
            else if (mode == GravityRight)
            {
                Physics2D.gravity = new Vector2(s_gravity, 0);
                print("right");
            }
            // Left
            else if (mode == GravityLeft)
            {
                Physics2D.gravity = new Vector2(-s_gravity, 0);
                print("left");
            }
            _unpressChooseSide?.Invoke();
            StartCoroutine(CanUseDelay(_delayBetweenChoosing));
        }


        public void EnableSlowMotion()
        {
            if (_isSlowMo) return;
            _isSlowMo = true;

            Time.timeScale *= _slowMoEffect;
            Time.fixedDeltaTime *= _slowMoEffect;
        }

        public void DisableSlowMotion()
        {
            if (!_isSlowMo) return;
            _isSlowMo = false;

            Time.timeScale = _normalTimeScale;
            Time.fixedDeltaTime = _normalFixedTime;
        }

        public void Interact()
        {
            var range = _interactComponent.CheckRange();

            foreach(var check in range)
            {
                var interactActionComponent = check.GetComponent<OnInteractAction>();

                if(interactActionComponent != null)
                    interactActionComponent.DoAction();
            }
        }
    }
}
// normal gravity = -9.81