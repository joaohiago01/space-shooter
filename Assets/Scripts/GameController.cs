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
    private PlayerInfo playerInfo;
    private GameData data;

    // Start is called before the first frame update
    void Start()
    {
        data = SaveSystem.LoadPlayer();
        if (data == null)
        {
            playerInfo = new PlayerInfo();

            playerInfo.crystalPlayer = 10000;

            SaveSystem.SavePlayer(playerInfo, currentShip);
            data = SaveSystem.LoadPlayer();
        }
        crystalPlayer = data.playerData.crystalPlayer;
        shipsPlayer = GetShipsData(data.shipsData);

        DontDestroyOnLoad(this.gameObject);

        ShipInfo temp = Instantiate(currentShip);
        shipsPlayer.Add(temp);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setCrystalPlayer(int gold)
    {
        crystalPlayer = gold;
    }
    public int getCrystalPlayer()
    {
        return crystalPlayer;
    }

    public ShipInfo getShip(int id)
    {
        if (id > shipsPlayer.Count)
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
        if (crystalPlayer < ship.cost)
        {
            return false;
        }

        crystalPlayer -= ship.cost;

        playerInfo.crystalPlayer = crystalPlayer;
        SaveSystem.SavePlayer(playerInfo, ship);

        data = SaveSystem.LoadPlayer();

        crystalPlayer = data.playerData.crystalPlayer;
        shipsPlayer = GetShipsData(data.shipsData);

        //shipsPlayer.Add(ship);

        return true;
    }

    private List<ShipInfo> GetShipsData(ShipsData shipsData)
    {
        List<ShipInfo> shipInfos = new List<ShipInfo>();

        foreach (ShipData ship in shipsData.ships)
        {
            ShipInfo shipInfo = new ShipInfo();
            shipInfo.shipName = ship.shipName;
            shipInfo.cost = ship.cost;
            shipInfo.damage = ship.damage;
            shipInfo.life = ship.life;
            shipInfo.speed = ship.speed;
            //shipInfo.shipSprite = ship.shipSprite;

            shipInfos.Add(shipInfo);
        }

        return shipInfos;
    }
}
