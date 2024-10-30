using UnityEngine;

using Collectable;
using Collectable.Managers;

using UI;
using DataModel;
using Sounds;

namespace Infrastructure
{
    [RequireComponent(typeof(CoinsManager))]
    [RequireComponent(typeof(UpdateUI))]
    [RequireComponent(typeof(AudioManagerObserver))]
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            var coinsManager = GetComponent<CoinsManager>();
            coinsManager.Initialize();

            var coins = FindObjectsOfType<Coin>();
            InitializeCoins(coins);

            var session = FindObjectOfType<GameSession>();
            session.Initialize();
            
            var updateUI = GetComponent<UpdateUI>();
            updateUI.Initialize(session, coinsManager);

            var audioManagerObserver = GetComponent<AudioManagerObserver>();
            audioManagerObserver.Initialize(coinsManager);
        }

        private void InitializeCoins(Coin[] coins)
        {
            foreach (var coin in coins)
            {
                coin.Initialize(CoinsManager.Instance);
            }
        }
    }
}