using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public PlayerData playerData;

    public ShipsData shipsData;

    public GameData(PlayerData playerData, ShipsData shipsData)
    {
        this.playerData = playerData;
        this.shipsData = shipsData;
    }
}
