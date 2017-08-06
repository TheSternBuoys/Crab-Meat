using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    public float timeAlive;
    public float scaleAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeAlive -= Time.deltaTime;
        transform.localScale = new Vector3(transform.localScale.x + scaleAmount, transform.localScale.y + scaleAmount, transform.localScale.z + scaleAmount);
        if(timeAlive <= 0)
        {
            Destroy(gameObject);
        }
	}
}
