using TMPro;
using twbG.Model;
using UnityEngine;

namespace twbG.UI
{
    public class UpdateUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinCount;

        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            OnChangeUI();
        }

        public void OnChangeUI()
        {
            _coinCount.text = "x" + _session.Data.coins.ToString();
        }
    }
}