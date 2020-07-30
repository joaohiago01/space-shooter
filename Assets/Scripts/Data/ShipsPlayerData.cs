using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipsPlayerData
{
    public List<ShipData> shipsPlayer = new List<ShipData>();

    public ShipsPlayerData(ShipData shipData)
    {
        shipsPlayer.Add(shipData);
    }
}
