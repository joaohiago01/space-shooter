using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProfileController : MonoBehaviour
{

    [SerializeField]
    private GameObject garageViewObject;
    [SerializeField]
    private GameObject profileViewObject;

    [SerializeField]
    private Text LevelText;
    [SerializeField]
    private Text xpText;


    [SerializeField]
    private Text shipNameTxt;
    [SerializeField]
    private Image shipImage;

    [SerializeField]
    private Text missileNameTxt;
    [SerializeField]
    private Image missileImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GarageView()
    {
        profileViewObject.SetActive(false);
        garageViewObject.SetActive(true);
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
}
