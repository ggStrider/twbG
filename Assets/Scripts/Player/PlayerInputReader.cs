using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(PlayerSystem))]
    public class PlayerInputReader : MonoBehaviour
    {
        private PlayerSystem _playerSystem;
        private PlayerControllers _playerActionMap;

        private void Awake()
        {
            _playerSystem = GetComponent<PlayerSystem>();

            _playerActionMap = new PlayerControllers();

            _playerActionMap.PlayerMainControllers.ChangeGravity.performed += OnChangeGravity;
            _playerActionMap.PlayerMainControllers.ChangeGravity.canceled += OnChangeGravity;

            _playerActionMap.PlayerMainControllers.Interact.started += OnInteract;

            _playerActionMap.Enable();
        }

        private void OnDisable()
        {
            _playerActionMap.Dispose();
        }

        private void OnChangeGravity(InputAction.CallbackContext context)
        {
            var isPressing = context.ReadValue<float>();
            _playerSystem.OnChangingGravity(isPressing > 0);
        }

        private void OnInteract(InputAction.CallbackContext context)
        {
            _playerSystem.Interact();
        }
    }
}