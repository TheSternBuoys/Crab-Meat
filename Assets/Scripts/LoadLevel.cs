using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadLevel : MonoBehaviour {

	public GameObject wall;
	public GameObject player;
	public string path;
	string baseText;
	string[] lines;
	string[] lineData;

	// Use this for initialization
	void Start () {

		//Reads in the CSV and splits the lines into seperate values
		baseText = File.ReadAllText (path);
		lines = baseText.Split("\n"[0]);
		instantiateObjects ();
	}

	//Spawns gameObjects based on the string
	public void instantiateObjects()
	{
		//1st for loop is for which line of text too use
		for (int y = 0; y < lines.Length; y++) 
		{
			//trims the current line into seperate values
			lineData = (lines [y].Trim ()).Split ("," [0]);

			//2nd Nested for loop reads each value in the line selected in the 1st for loop
			for (int x = 0; x < lineData.Length; x++) 
			{
				if (lineData [x] == "#") 
				{
					Instantiate (wall, transform.position = (new Vector3(Mathf.Round(x),Mathf.Round(y),transform.position.z)), Quaternion.identity);
				} 
				if (lineData [x] == "P") 
				{
					Instantiate (player, transform.position = (new Vector3(Mathf.Round(x),Mathf.Round(y),transform.position.z)), Quaternion.identity);
				} 
				else 
				{
					Debug.Log ("nothing");
				}
			}
		}
	}
}
