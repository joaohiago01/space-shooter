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
    private GameData data;
    [SerializeField]
    private List<ShipInfo> shipPrefabs;
    [SerializeField]
    private List<string> shipsPrefabsNames;

    public int idCurrentShip;
    [SerializeField]
    private PlayerInfo playerInfo;
    private ShopController shopController;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);



    }
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = FindObjectOfType(typeof(PlayerInfo)) as PlayerInfo;
        shopController = FindObjectOfType(typeof(ShopController)) as ShopController;

        data = SaveSystem.LoadPlayer();
        if (data == null)
        {
            
            currentShip = Instantiate(Resources.Load("Ship 1", typeof(ShipInfo))) as ShipInfo;

            playerInfo.crystalPlayer = 10000;

            SaveSystem.SavePlayer(playerInfo, new ShipsData(new ShipData(currentShip)));
            //data = SaveSystem.LoadPlayer();
        }
        crystalPlayer = data.playerData.crystalPlayer;
        
        shipsPlayer = GetShipsData(data.shipsData);
        currentShip = shipsPlayer[0];
              
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Interactable()
    {

        foreach (ShipData ship in data.shipsData.ships)
        {
            switch (ship.shipNamePrefab) {

                case "Ship 1":
                    shopController.buttonsShips[0].interactable = false;
                    break;
                case "Ship 2":
                    shopController.buttonsShips[1].interactable = false;
                    break;
                case "Ship 3":
                    shopController.buttonsShips[2].interactable = false;
                    break;
            }
        }
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
        shipsPrefabsNames.Add(ship.namePrefab);

        playerInfo.crystalPlayer = crystalPlayer;
        
   
        crystalPlayer = data.playerData.crystalPlayer;

        ShipInfo x = Resources.Load(ship.namePrefab, typeof(ShipInfo)) as ShipInfo;

        ShipInfo temp = Instantiate(x);

        shipsPlayer.Add(temp);

        ShipsData shipsData = data.shipsData;

        shipsData.ships.Add(new ShipData(temp));

        SaveSystem.SavePlayer(playerInfo, shipsData);
        //shipsPlayer.Add(ship);

        return true;
    }

    private List<ShipInfo> GetShipsData(ShipsData shipsData)
    {
        List<ShipInfo> shipInfos = new List<ShipInfo>();
   
        foreach(ShipData ship in data.shipsData.ships)
        {
           
            ShipInfo instance = Instantiate(Resources.Load(ship.shipNamePrefab, typeof(ShipInfo))) as ShipInfo;
            shipInfos.Add(instance);
        }
        
        return shipInfos;
    }

   
}
