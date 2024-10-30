using Collectable.Managers;
using UnityEngine;
using TMPro;

using Collectable.Observers;
using DataModel;

namespace UI
{
    public class UpdateUI : MonoBehaviour, ICoinAdded
    {
        [Header("Coin UI settings")]
        [SerializeField] private TextMeshProUGUI _coinCountTextComponent;
        [SerializeField] private string _textBeforeCoinsCount = "x";
        
        private GameSession _session;

        public void Initialize(GameSession session, CoinsManager coinsManager)
        {
            coinsManager.RegisterObserver(this);
            
            _session = session;
            UpdateAllUI();
        }

        public void UpdateAllUI()
        {
            _coinCountTextComponent.text = $"{_textBeforeCoinsCount}{_session.Data.Coins}";
        }

        public void OnCoinAdded()
        {
            _coinCountTextComponent.text = $"{_textBeforeCoinsCount}{_session.Data.Coins}";
        }
    }
}