using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {


    public void MainMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    public void Options()
    {
        Application.LoadLevel("Options");
    }

    public void Credits()
    {
        Application.LoadLevel("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Quit");
    }

    public void LoadLevel1()
    {
        Application.LoadLevel("Level 1");
    }

    
}
