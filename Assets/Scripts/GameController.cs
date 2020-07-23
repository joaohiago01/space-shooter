using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int crystalPlayer;

    [SerializeField]
    private ShipInfo currentShip;

    [SerializeField]
    private List<ShipInfo> shipsPlayer;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        ShipInfo temp = Instantiate(currentShip);
        shipsPlayer.Add(temp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCrytalPlayer(int gold)
    {
        crystalPlayer = gold;
    }
    public int getCrystalPlayer()
    {
        return crystalPlayer;
    }

    public ShipInfo getShip(int id)
    {
        if(id > shipsPlayer.Count)
        {

           
            return shipsPlayer[0];
        }


        return shipsPlayer[id];
    }
    public ShipInfo getCurrentShip()
    {
        return currentShip;
    }
    public void setCurrentShip(ShipInfo ship)
    {
        currentShip = ship;
    }

    public int getShipsCount()
    {
        return shipsPlayer.Count;
    }

    public bool Buy(ShipInfo ship)
    {
        if(crystalPlayer < ship.cost)
        {
            return false;

        }

        crystalPlayer -= ship.cost;
        shipsPlayer.Add(ship);
        return true;

    }

}
