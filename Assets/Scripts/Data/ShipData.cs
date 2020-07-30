using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipData
{
    public string shipNamePrefab;

    public ShipData(ShipInfo shipInfo)
    {
        shipNamePrefab = shipInfo.namePrefab;
    }
}
