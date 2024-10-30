using Collectable.Managers;
using UnityEngine;

using Collectable.Observers;

namespace Sounds
{
    public class AudioManagerObserver : MonoBehaviour, ICoinAdded
    {
        [SerializeField] private PlaySound _coinTaken;

        public void Initialize(CoinsManager coinsManager)
        {
            coinsManager.RegisterObserver(this);
        }
        
        public void OnCoinAdded()
        {
            _coinTaken.Play();
        }
    }
}