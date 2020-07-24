using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipData
{
    public string shipName;
    //public Sprite shipSprite;
    public int damage;
    public float speed;
    public int life;
    public int cost;

    public ShipData(ShipInfo shipInfo)
    {
        shipName = shipInfo.shipName;
        //shipSprite = shipInfo.shipSprite;
        damage = shipInfo.damage;
        speed = shipInfo.speed;
        life = shipInfo.life;
        cost = shipInfo.cost;
    }
}
