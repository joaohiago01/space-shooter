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
    [SerializeField]
    private List<ShipInfo> shipPrefabs;
    private GameData gameData;
    public int idCurrentShip;
    [SerializeField]
    private PlayerInfo playerInfo;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = FindObjectOfType(typeof(PlayerInfo)) as PlayerInfo;

        gameData = SaveSystem.LoadPlayer();

        if (gameData == null)
        {
            Debug.Log(playerInfo);
            currentShip = Instantiate(Resources.Load("Ship 1", typeof(ShipInfo))) as ShipInfo;
            playerInfo.crystalPlayer = 10000;

            SaveSystem.SavePlayer(playerInfo, new ShipsPlayerData(new ShipData(currentShip)));
        }

        crystalPlayer = gameData.playerData.crystalPlayer;
        loadShipsPlayer(gameData.shipsPlayerData);
        currentShip = shipsPlayer[0];
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Interactable(ShopController shopController)
    {
        foreach (ShipData ship in gameData.shipsPlayerData.shipsPlayer)
        {
            switch (ship.shipNamePrefab)
            {
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
        if (id >= shipsPlayer.Count)
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

        ShipInfo instance = Resources.Load(ship.namePrefab, typeof(ShipInfo)) as ShipInfo;
        ShipInfo shipBuyInfo = Instantiate(instance);
        shipsPlayer.Add(shipBuyInfo);

        ShipsPlayerData shipsPlayerData = gameData.shipsPlayerData;
        shipsPlayerData.shipsPlayer.Add(new ShipData(shipBuyInfo));

        SaveSystem.SavePlayer(playerInfo, shipsPlayerData);
        crystalPlayer = playerInfo.crystalPlayer;

        return true;
    }
    private void loadShipsPlayer(ShipsPlayerData shipsData)
    {
        foreach (ShipData ship in gameData.shipsPlayerData.shipsPlayer)
        {
            ShipInfo instance = Instantiate(Resources.Load(ship.shipNamePrefab, typeof(ShipInfo))) as ShipInfo;
            shipsPlayer.Add(instance);
        }
    }
}
