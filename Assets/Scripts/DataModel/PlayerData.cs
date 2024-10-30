using UnityEngine;

using System;

namespace DataModel
{
    [Serializable]
    public class PlayerData
    {
        public int Coins;

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<PlayerData>(json);
        }
    }
}
