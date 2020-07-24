using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipsData
{
    public List<ShipData> ships = new List<ShipData>();

    public ShipsData(ShipData shipData)
    {
        ships.Add(shipData);
    }
}
