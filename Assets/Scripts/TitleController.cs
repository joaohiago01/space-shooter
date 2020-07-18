using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("navigateToMainMenuScene", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void navigateToMainMenuScene() {
        SceneManager.LoadScene("MainMenuScene");
    }
}
