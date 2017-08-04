using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

    Player playerObject;
    public LayerMask mask;
    public float distance;

    public RaycastHit hit;

    // Use this for initialization
    void Start () {
        playerObject = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TestCollision(Vector3 rayDirection)
    {
        if (Physics.Raycast(transform.position, rayDirection,out hit, distance, mask) == false)
        {
            Debug.Log("ssss");
            playerObject.rayCastBoulderCheck = true;
        }
        else
        {
            if (hit.collider.tag == "Hole")
            {
                Destroy(hit.collider.gameObject,0.5f);
                playerObject.rayCastBoulderCheck = true;
            }
            else
                playerObject.rayCastBoulderCheck = false;
        }
    }

    /*void OnCollisionEnter()
{
    foreach (Transform child in transform) {
        GameObject.Destroy (child.gameObject);
    }
}*/
}
