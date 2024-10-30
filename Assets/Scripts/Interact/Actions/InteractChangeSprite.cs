using UnityEngine;

namespace Interact.Actions
{
    public class InteractChangeSprite : MonoBehaviour, IInteract
    {
        [SerializeField] private Sprite _spriteOnInteracted;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            if (_spriteRenderer != null) return;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        public void Interact()
        {
            _spriteRenderer.sprite = _spriteOnInteracted;
        }
        
        #if UNITY_EDITOR
        private void OnValidate()
        {
            if (_spriteRenderer != null) return;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        #endif
    }
}