using UnityEngine;

using Collectable.Managers;

namespace Collectable
{
    public class Coin : MonoBehaviour
    {
        private CoinsManager _coinsManager;
        
        public void Initialize(CoinsManager coinManager)
        {
            _coinsManager = coinManager;
        }

        public void OnTakeCoin()
        {
            _coinsManager.OnCoinCollected();
            Destroy(gameObject);
        }
    }
}