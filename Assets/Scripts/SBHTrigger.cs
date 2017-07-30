using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBHTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		foreach (Transform child in transform) {
			GameObject.Destroy (child.gameObject);
		}
	}
}
