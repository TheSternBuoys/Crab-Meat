using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

	public int currentTurn;
	public bool turnOver;

	public GameController gameControllerObject;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void NextTurn()
	{
		currentTurn += 1;
		if(currentTurn == 1)
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y - 1, transform.position.z);
		}
		else if (currentTurn == 2) 
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.05f, transform.position.z);
		}
		else
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.95f, transform.position.z);
			currentTurn = 0;
		} 
	}

	public void moveUp()
	{
		
	}

	public void moveDown()
	{
		
	}
}
