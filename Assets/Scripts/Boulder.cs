using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

    Player playerObject;
    public LayerMask mask;
    public float distance;
    public RaycastHit hit;
    public GameController gameController;
    public float newPositionz;
    public float newPositionx;

    private void OnTriggerEnter(Collision collision)
    {
         if (collision.gameObject.tag == "Hazard")
            {
            Destroy(gameObject);
            }
    }

    // Use this for initialization
    void Start () {
        playerObject = GameObject.FindWithTag("Player").GetComponent<Player>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
	if(gameController.playersTurn == true)
        {     
            newPositionz = Mathf.Round(transform.position.z);
            newPositionx = Mathf.Round(transform.position.x);
            transform.position = new Vector3(newPositionx, transform.position.y, newPositionz);
        }
	}

    public void TestCollision(Vector3 rayDirection)
    {
        if (Physics.Raycast(transform.position, rayDirection,out hit, distance, mask) == true)
        {
            if (hit.collider.tag == "Wall")
            {
                Debug.Log("Collision");
                playerObject.rayCastBoulderCheck = false;
            }
            if (hit.collider.tag == "Hole")
            {
                Debug.Log("HoleDestroyed");
                Destroy(hit.collider.gameObject,1.0f);
                playerObject.rayCastBoulderCheck = true;
            }
        }
        else
        {
            Debug.Log("Movement");
            playerObject.rayCastBoulderCheck = true;
        }
    }

    /*void OnCollisionEnter()
{
    foreach (Transform child in transform) {
        GameObject.Destroy (child.gameObject);
    }
}*/
}
