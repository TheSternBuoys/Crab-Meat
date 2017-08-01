using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

    Player playerObject;
    public LayerMask mask;

    public float distance;

    // Use this for initialization
    void Start () {
        playerObject = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TestCollision(Vector3 rayDirection)
    {
        if (Physics.Raycast(transform.position, rayDirection, distance, mask) == false)
        {
            gameObject.layer = 0;
        }
        else
            gameObject.layer = 5;
    }
}
