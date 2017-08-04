using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour {

    public float distanceToMove;
    public float moveSpeed;
    public float distance;
    public float turntTimer;
    public LayerMask mask;
    public RaycastHit hit;
    public bool rayCastBoulderCheck;
    public bool turnOver;
    public string direction;

    Vector3 rayCastDirection;
    private bool moveToEnd = false;
    private Vector3 endPosition;
    private GameController gameController;

    // Use this for initialization
    void Start ()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveToEnd == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void NextTurn()
    {
        if (direction == "up")
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, distance, mask) == false)
            {
                Movement(endPosition.x, endPosition.z + distanceToMove);
            }
        }
    }

    public void Movement(float x, float z)
    {
        endPosition = new Vector3(x, endPosition.y, z);
        moveToEnd = true;
        gameController.nextTurn();
    }
}
