using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float distanceToMove;
	public float moveSpeed;
	public float distance;
	public float turntTimer;
	public LayerMask mask;
	public LayerMask destructable;
	public GameController gameController;
    public string playerDirection;
    public GameObject shell;
    public bool shellMode;

    RaycastHit hit;
    Vector3 rayCastDirection;
    private bool moveToEnd = false;
	private Vector3 endPosition;

    private Vector2 touchOrigin = -Vector2.one;



    //Placeholder for next level stuff
    string SceneName;

    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Portal") 
		{
			if (SceneName == "Level 1") 
			{
				Application.LoadLevel ("Level 2");
			} 
			else if (SceneName == "Level 2") 
			{
				Application.LoadLevel ("Level 3");
			} 
			else if (SceneName == "Level 3") 
			{
				Application.LoadLevel ("Level 4");
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
                Application.LoadLevel("Level 7");
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

#if UNITY_STANDALONE || UNITY_WEBPLAYER

            //keycode
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
                playerDirection = "up";
                rayCastDirection = new Vector3(0, 0, 1);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == false)
                {
                    Movement(endPosition.x, endPosition.z + distanceToMove);
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                playerDirection = "down";
                rayCastDirection = new Vector3(0, 0, -1);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == false)
                {
                    Movement(endPosition.x, endPosition.z - distanceToMove);
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.localEulerAngles = new Vector3(0, 270, 0);
                playerDirection = "right";
                rayCastDirection = new Vector3(1, 0, 0);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == false)
                {
                    Movement(endPosition.x + distanceToMove, endPosition.z);
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.localEulerAngles = new Vector3(0, 90, 0);
                playerDirection = "left";
                rayCastDirection = new Vector3(-1, 0, 0);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == false)
                {
                    Movement(endPosition.x - distanceToMove, endPosition.z);
                }

            }
            /*if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == false)
            {
                if (hit.collider.tag == "Boulder")
                {
                    hit.transform.SendMessageUpwards("TestCollision", rayCastDirection);
                }
            }*/

#else
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
                }
			}
			else if (vertical == -1) 
                transform.localEulerAngles = new Vector3(0, 0, 0);
                playerDirection = "down";
                rayCastDirection = new Vector3(0, 0, -1);
                if (Physics.Raycast(transform.position, rayCastDirection, out hit, distance, mask) == false)
                {
                    Movement(endPosition.x, endPosition.z - distanceToMove);
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
                }
			}
#endif     
        }
    }

	public void Movement(float x, float z)
	{
        endPosition = new Vector3(x, endPosition.y, z);
        if (shellMode == false)
        {
            moveToEnd = true;
            gameController.nextTurn();
        }
        else if(shellMode == true)
        {
            shellMode = false;
            Instantiate(shell, endPosition, Quaternion.identity);
            endPosition = transform.position;
        }
	}

    public void DropShell()
    {
        if (shellMode == true)
            shellMode = false;
        else
            shellMode = true;

        Debug.Log("ShellDrop");
    }

    /*void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Hazard")
			Destroy (gameObject);
	}*/

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

    /*//keycode
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (Physics.Raycast(transform.position, transform.forward, distance, mask) == false)
				{
                    transform.localEulerAngles = new Vector3(0, 180, 0);
					Movement(endPosition.x, endPosition.z + distanceToMove);
				}
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				if (Physics.Raycast(transform.position, transform.forward * -1f, distance, mask) == false)
				{
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                    Movement(endPosition.x, endPosition.z - distanceToMove);
				}
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				if (Physics.Raycast(transform.position, transform.right, distance, mask) == false)
				{
                    transform.localEulerAngles = new Vector3(0, 270, 0);
                    Movement(endPosition.x + distanceToMove, endPosition.z);
				}
			}
			else if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (Physics.Raycast(transform.position, transform.right * -1f, distance, mask) == false)
				{
                    transform.localEulerAngles = new Vector3(0, 90, 0);
                    Movement(endPosition.x - distanceToMove, endPosition.z);
				}
			}*/
}
