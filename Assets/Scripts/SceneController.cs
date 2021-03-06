﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public GameObject Loading;
    public GameObject Pause;

    public void MainMenu()
    {
        Application.LoadLevel("Main Menu");
        Time.timeScale = 1;
        if (Loading.activeInHierarchy == false)
        {
            Time.timeScale = 1;
            Loading.SetActive(true);
        }
    }

    public void Credits()
    {
        Application.LoadLevel("Credits");
        Time.timeScale = 1;
        if (Loading.activeInHierarchy == false)
        {
            Time.timeScale = 1;
            Loading.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Quit");
        Time.timeScale = 1;
        if (Loading.activeInHierarchy == false)
        {
            Time.timeScale = 1;
            Loading.SetActive(true);
        }
    }

    public void LoadLevel1()
    {
        Application.LoadLevel("Level 1");
        Time.timeScale = 1;
        if (Loading.activeInHierarchy == false)
        {
            Time.timeScale = 1;
            Loading.SetActive(true);
        }
    }

    public void LoadIntroCutscene()
    {
        Application.LoadLevel("Intro");
        Time.timeScale = 1;
        if (Loading.activeInHierarchy == false)
        {
            Time.timeScale = 1;
            Loading.SetActive(true);
        }
    }

    public void Retry()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
        if (Loading.activeInHierarchy == false)
        {
            Time.timeScale = 1;
            Loading.SetActive(true);
        }
    }
    
    public void UnPauseGame()
    {
             if (Pause.activeInHierarchy == true)
        {
            Time.timeScale = 1;
            Pause.SetActive(false);
        }
    }

    public void PauseGame()
    {
        if (Pause.activeInHierarchy == false)
        {
            Time.timeScale = 0;
            Pause.SetActive(true);
        }
    }


}
