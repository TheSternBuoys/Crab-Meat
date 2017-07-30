using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float distanceToMove;
	public float moveSpeed;
	public float distance;
	public float turntTimer;
	public LayerMask mask;
	public LayerMask destructable;
	public GameController gameController;

	private bool moveToEnd = false;
	private Vector3 endPosition;

	Ray ray;
	RaycastHit hit;

	// Use this for initialization
	void Start () 
	{
		gameController = GameObject.FindWithTag ("GameController").GetComponent<GameController> ();
		turntTimer = gameController.startingTimer;
		endPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (moveToEnd == true) 
		{
			transform.position = Vector3.MoveTowards (transform.position, endPosition, moveSpeed * Time.deltaTime);
		}
	}

	void Update()
	{
		if (gameController.playersTurn == true) 
		{
			if (Input.GetKeyDown (KeyCode.UpArrow)) 
			{
				if (Physics.Raycast (transform.position, transform.forward, distance, mask) == false) 
				{
					Movement (endPosition.x, endPosition.z + distanceToMove);
				}
			} 
			else if (Input.GetKeyDown (KeyCode.DownArrow)) 
			{
				if (Physics.Raycast (transform.position, transform.forward * -1f, distance, mask) == false) {
					Movement (endPosition.x, endPosition.z - distanceToMove);
				}
			} 
			else if (Input.GetKeyDown (KeyCode.RightArrow)) 
			{
				if (Physics.Raycast (transform.position, transform.right, distance, mask) == false) {
					Movement (endPosition.x + distanceToMove, endPosition.z);
				}
			} 
			else if (Input.GetKeyDown (KeyCode.LeftArrow)) 
			{
				if (Physics.Raycast (transform.position, transform.right * -1f, distance, mask) == false) {
					Movement (endPosition.x - distanceToMove, endPosition.z);
				}
			}
		}
	}

	public void Movement(float x, float z)
	{
		endPosition = new Vector3 (x, endPosition.y, z);
		moveToEnd = true;
		gameController.nextTurn ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Hazard")
			Destroy (gameObject);
	}

	/*if (Physics.Raycast (ray, out hit, distance)) 
	Ray ray = new Ray (transform.position,transform.forward);
			RaycastHit hit;
			if (Physics.Raycast(ray,out hit,distance))
			{
				Debug.Log ("ee");
				if (hit.collider.gameObject.layer == 9) 
				{
					Destroy (hit.collider.gameObject);
				} 
				if (hit.collider.gameObject.layer == 8) 
				{
					Debug.Log ("woo");
				} 
			}
			else
			{
				endPosition = new Vector3 (endPosition.x, endPosition.y, endPosition.z + distanceToMove);
				moveToEnd = true;
			}*/
}
