using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipInfo : MonoBehaviour
{
    public string shipName;
    public Sprite shipSprite;
    public int damage;
    public float speed;
    public int life;
    public int cost;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
