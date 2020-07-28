using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void navigateToStartScene() {
        SceneManager.LoadScene("StartScene");
    }

    public void navigateToMapScene() {
        SceneManager.LoadScene("MapScene");
    }

    public void navigateToShopScene() {
        SceneManager.LoadScene("ShopScene");
    }

    public void navigateToProfileScene() {

        

        SceneManager.LoadScene("ProfileScene");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
