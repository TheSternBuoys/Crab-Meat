using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public float turnTimer;
	public float startingTimer;
	public bool playersTurn;
	public GameObject[] hazards;
    public float deathTimer;
    public bool death = false;
    public int iceAmount;
    public int iceDeath;

    private Player player;
    private float refreshTimer = 0.5f;
    private bool done = false;

	// Use this for initialization
	void Start () {
        turnTimer = startingTimer;   
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
            playersTurn = true;
            turnTimer = startingTimer;
            }
        }
	}

    void Refresh()
    {
        hazards = GameObject.FindGameObjectsWithTag("Hazard");
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

	public void nextTurn()
	{
		playersTurn = false;
	}

    public void increaseIce()
    {
        iceAmount++;
        if(iceAmount == iceDeath)
        {
            player.Death();
            death = true;
        }
    }
}
