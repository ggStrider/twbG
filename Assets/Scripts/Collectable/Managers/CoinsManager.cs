using UnityEngine;

using System.Collections.Generic;
using Collectable.Observers;

namespace Collectable.Managers
{
    public class CoinsManager : MonoBehaviour
    {
        private readonly List<ICoinAdded> _coinAddedObservers = new List<ICoinAdded>();
        
        private static CoinsManager _instance;
        public static CoinsManager Instance => _instance;

        public void Initialize()
        {
            if(_instance == null) _instance = this;
        }

        public void OnCoinCollected()
        {
            NotifyObservers();
        }

        public void RegisterObserver(ICoinAdded observer)
        {
            if(_coinAddedObservers.Contains(observer)) return;
            _coinAddedObservers.Add(observer);
        }

        public void RegisterObserverFirstInList(ICoinAdded observer)
        {
            if(_coinAddedObservers.Contains(observer)) return;
            _coinAddedObservers.Insert(0, observer);
        }

        private void NotifyObservers()
        {
            foreach (var observer in _coinAddedObservers)
            {
                observer.OnCoinAdded();
            }
        }

        private void OnDisable()
        {
            _coinAddedObservers.Clear();
        }
    }
}