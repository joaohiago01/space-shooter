using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [HideInInspector]
    public int crystalPlayer;

    public PlayerData(PlayerInfo playerInfo)
    {
        crystalPlayer = playerInfo.crystalPlayer;
    }
}
