using Collectable.Managers;
using Collectable.Observers;
using UnityEngine;

namespace DataModel
{
    public class GameSession : MonoBehaviour, ICoinAdded
    {
        [SerializeField] private PlayerData _data;
        
        public PlayerData Data => _data;
        public PlayerData _save;
        
        public static GameSession Instance { get; private set; }

        private void Awake()
        {
            if (IsSessionsExist())
            {
                DestroyImmediate(gameObject);
                return;
            }
            DontDestroyOnLoad(this);
            
            if(Instance == null) Instance = this;
        }

        public void Initialize(CoinsManager coinsManager)
        {
            coinsManager.RegisterObserverFirstInList(this);
        }

        private bool IsSessionsExist()
        {
            var sessions = FindObjectsOfType<GameSession>();

            foreach(var session in sessions)
            {
                if(session != this)
                    return true;
            }
            return false;
        }

        public void Save()
        {
            _save = _data.Clone();
        }

        public void Load()
        {
            _data = _save.Clone();
        }

        public void OnCoinAdded()
        {
            _data.Coins++;
        }
    }
}