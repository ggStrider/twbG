using UnityEngine;

using Collectable;
using Collectable.Managers;

using UI;
using DataModel;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            var coinsManager = FindObjectOfType<CoinsManager>();
            coinsManager.Initialize();

            var coins = FindObjectsOfType<Coin>();
            InitializeCoins(coins);

            var session = FindObjectOfType<GameSession>();
            session.Initialize();
            
            var updateUI = FindObjectOfType<UpdateUI>();
            updateUI.Initialize(session, coinsManager);
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