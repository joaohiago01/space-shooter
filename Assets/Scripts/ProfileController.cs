using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProfileController : MonoBehaviour
{
    [SerializeField]
    private ShipInfo shipSelected;
    [SerializeField]
    private int idShipSelected;

    [SerializeField]
    private GameObject garageViewObject;
    [SerializeField]
    private GameObject profileViewObject;

    [SerializeField]
    private Text LevelText;
    [SerializeField]
    private Text xpText;

    [SerializeField]
    private Text CrystalText;

    [SerializeField]
    private Text shipNameTxt;
    [SerializeField]
    private Image shipImage;

    [SerializeField]
    private Text missileNameTxt;
    [SerializeField]
    private Image missileImage;

    [SerializeField]
    private Button nextShipButton;
    [SerializeField]
    private Button backShipButton;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        CrystalText.text = gameController.getCrystalPlayer().ToString();
        shipSelected = gameController.getCurrentShip();

        if (gameController.getShipsCount() < 2)
        {
            nextShipButton.interactable = false;
            backShipButton.interactable = false;
        }
    }
    public void GarageView()
    {
        profileViewObject.SetActive(false);
        garageViewObject.SetActive(true);
        UpdateUI();
    }
    public void backGarageView()
    {
        garageViewObject.SetActive(false);
        profileViewObject.SetActive(true);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void UpdateUI()
    {
        shipNameTxt.text = shipSelected.shipName;
        shipImage.sprite = shipSelected.shipSprite;
    }
    public void nextShip(int id)
    {
        idShipSelected += id;

        if ((idShipSelected) > gameController.getShipsCount())
        {
            print(gameController.getShipsCount());
            shipSelected = gameController.getShip(0);
            idShipSelected = 0;
        }
        else
        {
            shipSelected = gameController.getShip(idShipSelected);
            gameController.setCurrentShip(gameController.getShip(idShipSelected));
        }
        UpdateUI();
    }
    public void backShip(int id)
    {
        idShipSelected -= id;

        if (idShipSelected < 0)
        {
            shipSelected = gameController.getShip(gameController.getShipsCount());
            idShipSelected = gameController.getShipsCount();
        }
        else
        {
            shipSelected = gameController.getShip(idShipSelected);
            gameController.setCurrentShip(gameController.getShip(idShipSelected));
        }
        UpdateUI();
    }
}
