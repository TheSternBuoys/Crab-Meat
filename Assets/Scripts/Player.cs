using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float distanceToMove;
	public float moveSpeed;
	public float distanceCheck;
	public LayerMask mask;

	private bool moveToEnd = false;
	private Vector3 endPosition;

	// Use this for initialization
	void Start () 
	{
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
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			if (Physics.Raycast (transform.position, transform.forward, distanceCheck, mask) == false) 
			{
				endPosition = new Vector3 (endPosition.x, endPosition.y, endPosition.z + distanceToMove);
				moveToEnd = true;
			}
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			if (Physics.Raycast (transform.position, transform.forward * -1f, distanceCheck, mask) == false) 
			{
				endPosition = new Vector3 (endPosition.x, endPosition.y, endPosition.z - distanceToMove);
				moveToEnd = true;
			}
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			if (Physics.Raycast (transform.position, transform.right, distanceCheck, mask) == false) 
			{
				endPosition = new Vector3 (endPosition.x + distanceToMove, endPosition.y, endPosition.z);
				moveToEnd = true;
			}

		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			if (Physics.Raycast (transform.position, transform.right * -1f, distanceCheck, mask) == false) 
			{
				endPosition = new Vector3 (endPosition.x - distanceToMove, endPosition.y, endPosition.z);
				moveToEnd = true;
			}
		}
	}
}
