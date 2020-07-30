using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public PlayerData playerData;

    public ShipsPlayerData shipsPlayerData;

    public GameData(PlayerData playerData, ShipsPlayerData shipsData)
    {
        this.playerData = playerData;
        this.shipsPlayerData = shipsData;
    }
}
