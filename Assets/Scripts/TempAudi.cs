using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempAudi : MonoBehaviour
{

    public int CurrentLevel;
    public GameObject BeachMusic;
    public GameObject AtlantisMusic;
    public GameObject Cutscene;
    public GameObject Menu;
    public GameObject DeathAudio;

    public GameObject IceAudio;

    public int LevelValue;


    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        BeachMusic = GameObject.Find("Beach");
        AtlantisMusic = GameObject.Find("Atlantis(Reef)");
        Cutscene = GameObject.Find("Cutscene(Atlantis)");
        Menu = GameObject.Find("Menu");

       DeathAudio = GameObject.Find("Death");




    }
    public void Update()
    {
       
    }

    public void DeathSound()
    {
        DeathAudio.GetComponent<AudioSource>().Play();
    }

    void OnLevelWasLoaded()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        if (CurrentLevel == 0)
        {
           
            AtlantisMusic.GetComponent<AudioSource>().Stop();
            BeachMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Play();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 1)
        {
            
            AtlantisMusic.GetComponent<AudioSource>().Stop();
            BeachMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Play();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 2)
        {
            BeachMusic.GetComponent<AudioSource>().Stop();
            AtlantisMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Play();
        }
        if (CurrentLevel == 3)
        {
            BeachMusic.GetComponent<AudioSource>().Play();
            AtlantisMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 4)
        {
            
            AtlantisMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 5)
        {
            
            AtlantisMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 6)
        {
            
            AtlantisMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 7)
        {
            
            AtlantisMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 8)
        {
            
            AtlantisMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 9)
        {
            
            AtlantisMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 10)
        {
            
            AtlantisMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 11)
        {
            AtlantisMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 12)
        {

            AtlantisMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 13)
        {

            BeachMusic.GetComponent<AudioSource>().Stop();
            AtlantisMusic.GetComponent<AudioSource>().Play();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 14)
        {
            
            BeachMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 15)
        {
            
            BeachMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 16)
        {
            
            BeachMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 17)
        {
            
            BeachMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 18)
        {
            
            BeachMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 19)
        {
            
            BeachMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 20)
        {
            
            BeachMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }

        if (CurrentLevel == 21)
        {
            
            BeachMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }

    }

   /* void OnLevelWasLoaded()
    {
 
        //LevelCheck();
    }
    */

    void Start()
    {
        LevelCheck();
    }

    void LevelCheck()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        if (CurrentLevel >= 3 && CurrentLevel <= 12)
        {
            BeachMusic.GetComponent<AudioSource>().Play();
            AtlantisMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel >= 13)
        {
            AtlantisMusic.GetComponent<AudioSource>().Play();
            BeachMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel >= 0 && CurrentLevel <= 1)
        {
            AtlantisMusic.GetComponent<AudioSource>().Stop();
            BeachMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Play();
            Cutscene.GetComponent<AudioSource>().Stop();
        }
        if (CurrentLevel == 2)
        {
            AtlantisMusic.GetComponent<AudioSource>().Stop();
            BeachMusic.GetComponent<AudioSource>().Stop();
            Menu.GetComponent<AudioSource>().Stop();
            Cutscene.GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame




}
