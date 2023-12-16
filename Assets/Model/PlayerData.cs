using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int coins;

    public PlayerData Clone()
    {
        var json = JsonUtility.ToJson(this);
        return JsonUtility.FromJson<PlayerData>(json);
    }
}
