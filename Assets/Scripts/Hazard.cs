using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

	public int currentTurn;
	public bool turnOver;

	public GameController gameController;

	// Use this for initialization
	void Start ()
	{
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
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
			transform.position = new Vector3 (transform.position.x, 0.4f, transform.position.z);
		}
		else if (currentTurn == 2 || currentTurn == 3) 
		{
			transform.position = new Vector3 (transform.position.x, 0.55f, transform.position.z);
		}
		else
		{
			transform.position = new Vector3 (transform.position.x, 1.1f, transform.position.z);
			currentTurn = 0;
		}
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            gameController.death = true;
        }
        if (other.gameObject.tag == "Boulder")
        {
            Destroy(other.gameObject);
        }
    }
        
}
