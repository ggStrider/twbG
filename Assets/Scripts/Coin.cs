using twbG.Model;
using twbG.UI;
using UnityEngine;
using UnityEngine.Events;

namespace twbG.Mechanics
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onTake;
        private GameSession _session;
        private UpdateUI _updateUI;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            _updateUI = FindObjectOfType<UpdateUI>();
        }

        public void OnTakeCoin()
        {
            if(_session == null) return;

            _session.Data.coins++;

            _updateUI.OnChangeUI();
            _onTake?.Invoke();
        }
    }
}