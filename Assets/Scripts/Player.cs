using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float distanceToMove;
	public float moveSpeed;
	public float distance;
	public float turntTimer;
    public string playerDirection;
    public LayerMask mask;
	public LayerMask destructable;
    public GameObject HowToPlayMobile;
    public GameObject HowToPlayComputer;
    public RaycastHit hit;
    public bool rayCastBoulderCheck;

    Vector3 rayCastDirection;
    private bool moveToEnd = false;
	private Vector3 endPosition;
    private GameController gameController;

    private Vector2 touchOrigin = -Vector2.one;

    //Placeholder for next level stuff
    string SceneName;

    // Use this for initialization
    void Start () 
	{
		gameController = GameObject.FindWithTag ("GameController").GetComponent<GameController> ();
		turntTimer = gameController.startingTimer;
		endPosition = transform.position;

        //Placeholder for next level stuff
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneName = CurrentScene.name;
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
            int horizontal = 0;     //Used to store the horizontal move direction.
            int vertical = 0;       //Used to store the vertical move direction.


            //keycode
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
                playerDirection = "up";
                rayCastDirection = new Vector3(0, 0.5f, 1);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == true)
                {
                    if (hit.collider.tag == "Wall")
                    {
                        hit.collider.SendMessageUpwards("TestCollision", rayCastDirection, SendMessageOptions.DontRequireReceiver);
                        if (rayCastBoulderCheck == true)
                        {
                            Movement(endPosition.x, endPosition.z + distanceToMove);
                        }
                    }
                }
                else
                {
                    Movement(endPosition.x, endPosition.z + distanceToMove);
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                playerDirection = "down";
                rayCastDirection = new Vector3(0, 0.5f, -1);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == true)
                {
                    if (hit.collider.tag == "Wall")
                    {
                        hit.collider.SendMessageUpwards("TestCollision", rayCastDirection, SendMessageOptions.DontRequireReceiver);
                        if (rayCastBoulderCheck == true)
                        {
                            Movement(endPosition.x, endPosition.z - distanceToMove);
                        }
                    }
                }
                else
                {
                    Movement(endPosition.x, endPosition.z - distanceToMove);
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.localEulerAngles = new Vector3(0, 270, 0);
                playerDirection = "right";
                rayCastDirection = new Vector3(1, 0.5f, 0);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == true)
                {
                    if (hit.collider.tag == "Wall")
                    {
                        hit.collider.SendMessageUpwards("TestCollision", rayCastDirection, SendMessageOptions.DontRequireReceiver);
                        if (rayCastBoulderCheck == true)
                        {
                            Movement(endPosition.x + distanceToMove, endPosition.z);
                        }
                    }
                }
                else
                {
                    Movement(endPosition.x + distanceToMove, endPosition.z);
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                transform.localEulerAngles = new Vector3(0, 90, 0);
                playerDirection = "left";
                rayCastDirection = new Vector3(-1, 0.5f, 0);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == true)
                {
                    if (hit.collider.tag == "Wall")
                    {
                        hit.collider.SendMessageUpwards("TestCollision", rayCastDirection, SendMessageOptions.DontRequireReceiver);
                        if (rayCastBoulderCheck == true)
                        {
                            Movement(endPosition.x - distanceToMove, endPosition.z);
                        }
                    }
                }
                else
                {
                    Movement(endPosition.x - distanceToMove, endPosition.z);
                }
            }

            //HowToPlayComputer.SetActive(false);

            //Touch

            if (Input.touchCount > 0)
            {
                Touch myTouch = Input.touches[0];

                if (myTouch.phase == TouchPhase.Began)
                {
                    touchOrigin = myTouch.position;
                }

                else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
                {
                    Vector2 touchEnd = myTouch.position;
                    float x = touchEnd.x - touchOrigin.x;
                    float y = touchEnd.y - touchOrigin.y;
                    touchOrigin.x = -1;
                    if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        horizontal = x > 0 ? 1 : -1;
                    }

                    else
                    {
                        vertical = y > 0 ? 1 : -1;
                    }
                }
            }

            if (vertical == 1)
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
                playerDirection = "up";
                rayCastDirection = new Vector3(0, 0, 1);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == false)
                {
                    Movement(endPosition.x, endPosition.z + distanceToMove);
                    HowToPlayMobile.SetActive(false);
                }
            }
            else if (vertical == -1)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                playerDirection = "down";
                rayCastDirection = new Vector3(0, 0, -1);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == false)
                {
                    Movement(endPosition.x, endPosition.z - distanceToMove);
                    HowToPlayMobile.SetActive(false);
                }
            }
            else if (horizontal == 1)
            {
                transform.localEulerAngles = new Vector3(0, 270, 0);
                playerDirection = "right";
                rayCastDirection = new Vector3(1, 0, 0);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == false)
                {
                    Movement(endPosition.x + distanceToMove, endPosition.z);
                    HowToPlayMobile.SetActive(false);
                    
                }
            }
            else if (horizontal == -1)
            {
                transform.localEulerAngles = new Vector3(0, 90, 0);
                playerDirection = "left";
                rayCastDirection = new Vector3(-1, 0, 0);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == false)
                {
                    Movement(endPosition.x - distanceToMove, endPosition.z);
                    HowToPlayMobile.SetActive(false);
                }
            }
             rayCastBoulderCheck = false;
        }
    }
    
	public void Movement(float x, float z)
	{
        endPosition = new Vector3(x, endPosition.y, z);
        moveToEnd = true;
        gameController.nextTurn();
	}

    public void Death()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Portal")
        {
            if (SceneName == "Level 1")
            {
                Application.LoadLevel("Level 2");
            }
            else if (SceneName == "Level 2")
            {
                Application.LoadLevel("Level 5");
            }
            else if (SceneName == "Level 3")
            {
                Application.LoadLevel("Level 5");
            }
            else if (SceneName == "Level 4")
            {
                Application.LoadLevel("Level 5");
            }
            else if (SceneName == "Level 5")
            {
                Application.LoadLevel("Level 6");
            }
            else if (SceneName == "Level 6")
            {
                Application.LoadLevel("Level 9");
            }
            else if (SceneName == "Level 7")
            {
                Application.LoadLevel("Level 8");
            }
            else if (SceneName == "Level 8")
            {
                Application.LoadLevel("Level 9");
            }
            else if (SceneName == "Level 9")
            {
                Application.LoadLevel("Level 10");
            }
            else if (SceneName == "Level 10")
            {
                Application.LoadLevel("Level 11");
            }
            else if (SceneName == "Level 11")
            {
                Application.LoadLevel("Level 12");
            }
            else if (SceneName == "Level 12")
            {
                Application.LoadLevel("Main Menu");
            }
        }
    }
}
