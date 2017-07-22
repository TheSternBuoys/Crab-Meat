using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToCanvas : MonoBehaviour {

	[Tooltip("Tag name of the camera to add.")]
	public string cameraTagName;

	private Camera cam;

	// Use this for initialization
	void Start () {
		SetCamera ();
	}

	void SetCamera()
	{
		//Grabs the current canvas
		Canvas canvas = gameObject.GetComponent<Canvas> ();
		//Adds the camera based on the string of cameraTagName to cam variable
		cam = GameObject.FindGameObjectWithTag (cameraTagName).GetComponent<Camera>();
		if (canvas != null)
		{
			canvas.worldCamera = cam;
		}
	}
}
