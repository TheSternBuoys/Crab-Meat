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
    public string direction;
    public string crabType;

    Vector3 rayCastDirection;
    private bool moveToEnd = false;
    private Vector3 endPosition;
    private GameController gameController;

    // Use this for initialization
    void Start ()
    {
        endPosition = transform.position;
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveToEnd == true)
        {
            Debug.Log("FIxed");
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
            if(transform.position == endPosition)
            {
                moveToEnd = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {

    }

    public void NextTurn()
    {
        if (crabType == "horizontal")
        {
            if (direction == "left")
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                rayCastDirection = new Vector3(-1, 0.5f, 0);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == true)
                {
                    direction = "right";
                }
                else
                {
                    Movement(endPosition.x - distanceToMove, endPosition.z);
                }
            }
            else if (direction == "right")
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                rayCastDirection = new Vector3(1, 0.5f, 0);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == true)
                {
                    direction = "left";
                }
                else
                {
                    Movement(endPosition.x + distanceToMove, endPosition.z);
                }
            }
        }
        if (crabType == "vertical")
        {
            if (direction == "up")
            {
                transform.localEulerAngles = new Vector3(0, 90, 0);
                rayCastDirection = new Vector3(0, 0.5f, 1);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == true)
                {
                    direction = "down";
                }
                else
                {
                    Movement(endPosition.x, endPosition.z + distanceToMove);
                }
            }
            else if (direction == "down")
            {
                transform.localEulerAngles = new Vector3(0, 90, 0);
                rayCastDirection = new Vector3(0, 0.5f, -1);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == true)
                {
                    direction = "up";
                }
                else
                {
                    Movement(endPosition.x, endPosition.z - distanceToMove);
                }
            }
        }
    }

    public void Movement(float x, float z)
    {
        Debug.Log("Move");
        endPosition = new Vector3(x, endPosition.y, z);
        transform.position = endPosition;
        //moveToEnd = true;
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            gameController.Death();
        }
    }
}
