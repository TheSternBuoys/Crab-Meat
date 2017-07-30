using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public float turnTimer;
	public float startingTimer;
	public bool playersTurn;
	public GameObject[] hazards;

	// Use this for initialization
	void Start () {
		hazards = GameObject.FindGameObjectsWithTag ("Hazard");
		turnTimer = startingTimer;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void nextTurn()
	{
		playersTurn = false;
		for (int i = 0; i < hazards.Length; i++)
		{
			hazards [i].SendMessage ("NextTurn");
		}

		while (turnTimer < 0)
		{
			turnTimer -= Time.deltaTime;
		}

		playersTurn = true;
		turnTimer = startingTimer;
	}
}
