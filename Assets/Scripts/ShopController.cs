using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField]
    private GameObject shipsObjets;
    [SerializeField]
    private GameObject weaponsObjets;
    [SerializeField]
    private Text crystalTxt;
    [SerializeField]
    private GameController gameController;

    [SerializeField]
    public List<Button> buttonsShips;

    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        gameController.Interactable(this);
        UpdateUI();
    }
    void Update()
    {

    }
    public void ExitShop()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void Ships()
    {
        shipsObjets.SetActive(true);
        weaponsObjets.SetActive(false);
    }
    public void Weapons()
    {
        shipsObjets.SetActive(false);
        weaponsObjets.SetActive(true);
    }

    public void UpdateUI()
    {
        crystalTxt.text = gameController.getCrystalPlayer().ToString();
    }

    public void Buy(GameObject ship)
    {
        ShipInfo shipInfo = ship.GetComponent<ShipInfo>();
        gameController.Buy(shipInfo);
    }
}
