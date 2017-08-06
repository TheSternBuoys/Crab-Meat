using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public float turnTimer;
	public float startingTimer;
	public bool playersTurn;
	public GameObject[] hazards;
    public GameObject[] crabs;
    public float deathTimer;
    public bool death = false;
    public int iceAmount;
    public int iceDeath;
    public AudioClip PlayerDie;

    private Player player;
    private float refreshTimer = 0.5f;
    private bool done = false;

    [Header("Ice Colour")]
    public GameObject Player;
    public Color color = Color.black;

    // Use this for initialization
    private void Awake()
    {
        
    }

    void Start () {
        turnTimer = startingTimer;
        Refresh();
    }
	
	// Update is called once per frame
	void Update () {

        if (done == false)
        {
            if (refreshTimer > 0)
                refreshTimer -= Time.deltaTime;
            else
            {
                done = true;
                Refresh();
            }
        }
        if(death == true)
        {
            if (deathTimer > 0)
                deathTimer -= Time.deltaTime;
            else
                Application.LoadLevel(Application.loadedLevel);
        }
        if(playersTurn == false)
        {
            if (turnTimer > 0)
                turnTimer -= Time.deltaTime;
            else
            { 
                for (int i = 0; i < hazards.Length; i++)
                {
                    hazards[i].SendMessage("NextTurn");
                }
                for (int i = 0; i < crabs.Length; i++)
                {
                    crabs[i].SendMessage("NextTurn");
                }

                playersTurn = true;
            turnTimer = startingTimer;
            }
        }
	}

    void Refresh()
    {
        hazards = GameObject.FindGameObjectsWithTag("Hazard");
        crabs = GameObject.FindGameObjectsWithTag("Crab");
     //   player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

	public void nextTurn()
	{
		playersTurn = false;
	}

    public void IncreaseIce()
    {
        iceAmount += 1;

        if (iceAmount ==0)
        {
            
        }
        

        if(iceAmount >= iceDeath)
        {
            SoundManager.instance.PlaySingle(PlayerDie, false);
            Application.LoadLevel(Application.loadedLevel);
            death = true;
            
        }
       /* if (iceAmount == 1)
        {
            IceAudio.GetComponent<AudioSource>().volume = .3f;
            IceAudio.GetComponent<AudioSource>().Play();
        }
        if (iceAmount == 2)
        {
            IceAudio.GetComponent<AudioSource>().volume = .6f;
            IceAudio.GetComponent<AudioSource>().Play();
        }
        if (iceAmount == 3)
        {
            IceAudio.GetComponent<AudioSource>().volume = 1f;
            IceAudio.GetComponent<AudioSource>().Play();
        }*/


    }

    public void Reset()
    {
        iceAmount = 0;
    }
}
