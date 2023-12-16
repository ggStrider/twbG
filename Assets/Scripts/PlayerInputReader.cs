using UnityEngine;
using UnityEngine.InputSystem;

namespace twbG.PlayerSystemComponents
{
    public class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private PlayerSystem _playerSystem;

        private PlayerControllers _playerActionMap;

        private void Awake()
        {
            _playerActionMap = new PlayerControllers();

            _playerActionMap.PlayerMainControllers.ChangeGravity.performed += OnChangeGravity;
            _playerActionMap.PlayerMainControllers.ChangeGravity.canceled += OnChangeGravity;

            _playerActionMap.PlayerMainControllers.Interact.started += OnInteract;

            _playerActionMap.Enable();
        }

        private void OnDisable() =>
            _playerActionMap.Dispose();

        private void OnChangeGravity(InputAction.CallbackContext context)
        {
            var isPressing = context.ReadValue<float>();
            _playerSystem.ChangeGravity(isPressing > 0);
        }

        private void OnInteract(InputAction.CallbackContext context)
        {
            _playerSystem.Interact();
        }
    }
}