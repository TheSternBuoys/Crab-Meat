using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float distanceToMove;
    public float moveSpeed;
    public float distance;
    public float turntTimer;
    public string playerDirection;
    public Transform rayCastChild;
    public LayerMask mask;
    public GameObject HowToPlayMobile;
    public GameObject HowToPlayComputer;
    public GameObject cloud;
    public RaycastHit hit;
    public bool rayCastBoulderCheck;

    public GameObject HowToPlay;

    public AudioClip PlayerMove;
    public AudioClip iceCrack;
    public AudioClip wallBump;

    public static Player instance = null;

    private bool moveToEnd = false;
    private Vector3 endPosition;
    private GameController gameController;
    private Vector2 touchOrigin = -Vector2.one;
    Vector3 rayCastDirection;

    public GameObject FrozenCrab;
    public bool EnableInput;

    //Placeholder for next level
    string SceneName;

    // Use this for initialization
    void Start()
    {
        rayCastChild = this.gameObject.transform.GetChild(0);
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        turntTimer = gameController.startingTimer;
        endPosition = transform.position;

        //Placeholder for next level stuff
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneName = CurrentScene.name;

        HowToPlay = GameObject.Find("HowToPlay");
        EnableInput = true;
}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveToEnd == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
        }
    }

    void UpPC()
    {
        int horizontal = 0;     //Used to store the horizontal move direction.
        int vertical = 0;       //Used to store the vertical move direction.

        HowToPlay.SetActive(false);
        transform.localEulerAngles = new Vector3(0, 180, 0);
        playerDirection = "up";
        rayCastDirection = new Vector3(0, 0.5f, 1);
        if (Physics.Raycast(rayCastChild.position, rayCastDirection, out hit, distance, mask) == true)
        {
            if (hit.collider.tag == "Wall")
            {
                hit.collider.SendMessageUpwards("TestCollision", rayCastDirection, SendMessageOptions.DontRequireReceiver);
                if (rayCastBoulderCheck == true)
                {
                    Movement(endPosition.x, endPosition.z + distanceToMove);
                }
                else
                    SoundManager.instance.PlaySingle(wallBump, false);
            }
        }
        else
        {
            Movement(endPosition.x, endPosition.z + distanceToMove);
        }
    }

    void DownPC()
    {
        HowToPlay.SetActive(false);
        transform.localEulerAngles = new Vector3(0, 0, 0);
        playerDirection = "down";
        rayCastDirection = new Vector3(0, 0.5f, -1);
        if (Physics.Raycast(rayCastChild.position, rayCastDirection, out hit, distance, mask) == true)
        {
            if (hit.collider.tag == "Wall")
            {
                hit.collider.SendMessageUpwards("TestCollision", rayCastDirection, SendMessageOptions.DontRequireReceiver);
                if (rayCastBoulderCheck == true)
                {
                    Movement(endPosition.x, endPosition.z - distanceToMove);
                }
                else
                    SoundManager.instance.PlaySingle(wallBump, false);
            }
        }
        else
        {
            Movement(endPosition.x, endPosition.z - distanceToMove);
        }
    }

    void RightPC()
    {
        HowToPlay.SetActive(false);
        transform.localEulerAngles = new Vector3(0, 270, 0);
        playerDirection = "right";
        rayCastDirection = new Vector3(1, 0.5f, 0);
        if (Physics.Raycast(rayCastChild.position, rayCastDirection, out hit, distance, mask) == true)
        {
            if (hit.collider.tag == "Wall")
            {
                hit.collider.SendMessageUpwards("TestCollision", rayCastDirection, SendMessageOptions.DontRequireReceiver);
                if (rayCastBoulderCheck == true)
                {
                    Movement(endPosition.x + distanceToMove, endPosition.z);
                }
                else
                    SoundManager.instance.PlaySingle(wallBump, false);
            }
        }
        else
        {
            Movement(endPosition.x + distanceToMove, endPosition.z);
        }
    }

    void LeftPC()
    {

        HowToPlay.SetActive(false);
        transform.localEulerAngles = new Vector3(0, 90, 0);
        playerDirection = "left";
        rayCastDirection = new Vector3(-1, 0.5f, 0);
        if (Physics.Raycast(rayCastChild.position, rayCastDirection, out hit, distance, mask) == true)
        {
            if (hit.collider.tag == "Wall")
            {
                hit.collider.SendMessageUpwards("TestCollision", rayCastDirection, SendMessageOptions.DontRequireReceiver);
                if (rayCastBoulderCheck == true)
                {
                    Movement(endPosition.x - distanceToMove, endPosition.z);
                }
                else
                    SoundManager.instance.PlaySingle(wallBump, false);
            }
        }
        else
        {
            Movement(endPosition.x - distanceToMove, endPosition.z);
        }
    }

    void Update()
    {
        print(EnableInput);
        if (EnableInput == true)
        {

            if (gameController.playersTurn == true)
            {
                int horizontal = 0;     //Used to store the horizontal move direction.
                int vertical = 0;       //Used to store the vertical move direction.


                //keycode
                if (Input.GetKeyDown(KeyCode.W))
                {
					Invoke("UpPC",0f);
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
					Invoke("DownPC",0f);
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
					Invoke("RightPC",0f);
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
					Invoke("LeftPC",0f);
                }

                //HowToPlayComputer.SetActive(false);

                //Touch

                if (horizontal != 0)
                {
                    vertical = 0;
                }

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
                    HowToPlay.SetActive(false);
                    transform.localEulerAngles = new Vector3(0, 180, 0);
                    playerDirection = "up";
                    rayCastDirection = new Vector3(0, 0.5f, 1);
                    if (Physics.Raycast(rayCastChild.position, rayCastDirection, out hit, distance, mask) == true)
                    {
                        if (hit.collider.tag == "Wall")
                        {
                            hit.collider.SendMessageUpwards("TestCollision", rayCastDirection, SendMessageOptions.DontRequireReceiver);
                            if (rayCastBoulderCheck == true)
                            {
                                Movement(endPosition.x, endPosition.z + distanceToMove);
                            }
                            else
                                SoundManager.instance.PlaySingle(wallBump, false);
                        }
                    }
                    else
                    {
                        Movement(endPosition.x, endPosition.z + distanceToMove);
                    }
                }
                else if (vertical == -1)
                {
                    HowToPlay.SetActive(false);
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                    playerDirection = "down";
                    rayCastDirection = new Vector3(0, 0.5f, -1);
                    if (Physics.Raycast(rayCastChild.position, rayCastDirection, out hit, distance, mask) == true)
                    {
                        if (hit.collider.tag == "Wall")
                        {
                            hit.collider.SendMessageUpwards("TestCollision", rayCastDirection, SendMessageOptions.DontRequireReceiver);
                            if (rayCastBoulderCheck == true)
                            {
                                Movement(endPosition.x, endPosition.z - distanceToMove);
                            }
                            else
                                SoundManager.instance.PlaySingle(wallBump, false);
                        }
                    }
                    else
                    {
                        Movement(endPosition.x, endPosition.z - distanceToMove);
                    }
                }
                else if (horizontal == 1)
                {
                    HowToPlay.SetActive(false);
                    transform.localEulerAngles = new Vector3(0, 270, 0);
                    playerDirection = "right";
                    rayCastDirection = new Vector3(1, 0, 0);
                    if (Physics.Raycast(rayCastChild.position, rayCastDirection, out hit, distance, mask) == true)
                    {
                        if (hit.collider.tag == "Wall")
                        {
                            hit.collider.SendMessageUpwards("TestCollision", rayCastDirection, SendMessageOptions.DontRequireReceiver);
                            if (rayCastBoulderCheck == true)
                            {
                                Movement(endPosition.x + distanceToMove, endPosition.z);
                            }
                            else
                                SoundManager.instance.PlaySingle(wallBump, false);
                        }
                    }
                    else
                    {
                        Movement(endPosition.x + distanceToMove, endPosition.z);
                    }
                }
                else if (horizontal == -1)
                {
                    HowToPlay.SetActive(false);
                    transform.localEulerAngles = new Vector3(0, 90, 0);
                    playerDirection = "left";
                    rayCastDirection = new Vector3(-1, 0.5f, 0);
                    if (Physics.Raycast(rayCastChild.position, rayCastDirection, out hit, distance, mask) == true)
                    {
                        if (hit.collider.tag == "Wall")
                        {
                            hit.collider.SendMessageUpwards("TestCollision", rayCastDirection, SendMessageOptions.DontRequireReceiver);
                            if (rayCastBoulderCheck == true)
                            {
                                Movement(endPosition.x - distanceToMove, endPosition.z);
                            }
                            else
                                SoundManager.instance.PlaySingle(wallBump, false);
                        }
                    }
                    else
                    {
                        Movement(endPosition.x - distanceToMove, endPosition.z);
                    }
                }
                rayCastBoulderCheck = false;
            }
        }
    }

    public void Movement(float x, float z)
    {
        SoundManager.instance.PlaySingle(PlayerMove,true);
        Instantiate(cloud, transform.position, Quaternion.identity);
        endPosition = new Vector3(x, endPosition.y, z);
        moveToEnd = true;
        gameController.nextTurn();
    }

    public void Death()
    {
        gameController.Death();
        Destroy(gameObject);
    }

    public void IceSound(int iceAmount)
    {
        float pitchChange = 1;
        if(iceAmount == 1)
           pitchChange = 0.7f ;
        if (iceAmount == 2)
            pitchChange = 0.8f;
        if (iceAmount == 3)
            pitchChange = 0.9f;
        SoundManager.instance.PlaySinglePitch(iceCrack, pitchChange);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "IceBlock")
        {
            if (gameController.iceAmount == 3)
            {
                EnableInput = false;
                FrozenCrab.SetActive(true);
                Invoke("Death", 1.5f);
            }
            else
            {
                gameController.IncreaseIce();
            }
        }
        else
        {
            gameController.Reset();
        }
        if (other.gameObject.tag == "Portal")
        {
            if (SceneName == "Level 1")
            {
                Application.LoadLevel("Level 2");
            }
            else if (SceneName == "Level 2")
            {
                Application.LoadLevel("Level 3");
            }
            else if (SceneName == "Level 3")
            {
                Application.LoadLevel("Level 4");
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
                Application.LoadLevel("Level 13");
            }
            else if (SceneName == "Level 13")
            {
                Application.LoadLevel("Level 14");
            }
            else if (SceneName == "Level 14")
            {
                Application.LoadLevel("Level 15");
            }
            else if (SceneName == "Level 15")
            {
                Application.LoadLevel("Level 16");
            }
            else if (SceneName == "Level 16")
            {
                Application.LoadLevel("Level 17");
            }
            else if (SceneName == "Level 17")
            {
                Application.LoadLevel("Level 18");
            }
            else if (SceneName == "Level 18")
            {
                Application.LoadLevel("Level 19");
            }
            else if (SceneName == "Level 19")
            {
                Application.LoadLevel("Level 20");
            }
            else if (SceneName == "Level 20")
            {
                Application.LoadLevel("Outro");
            }
        }
    }
}
