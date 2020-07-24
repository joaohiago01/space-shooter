using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapContoller : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }
    public void startPhase(string phase)
    {
        SceneManager.LoadScene(phase);
    }
    public void backMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
