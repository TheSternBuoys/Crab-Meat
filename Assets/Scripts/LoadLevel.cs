using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadLevel : MonoBehaviour {
	public GameObject wall;
	public GameObject player;
	public GameObject sandGround;
	public GameObject reefGround;
	public GameObject atlantisGround;
	public int level;
	public int layer;
	public string levelString;
	public string layerString;
	public float objectSize;

	GameObject currentObject;
	string baseText;
	string[] lines;
	string[] lineData;
	float xChange;
	float zChange;


	// Use this for initialization
	void Start () {
		levelString = level.ToString (levelString);
		instantiateObjects ();
	}

	//Spawns gameObjects based on the string
	public void instantiateObjects()
	{
		for(layer = 1; layer < 3; layer++)
		{
			//Reads in the CSV and splits the lines into seperate values
			layerString = layer.ToString (layerString);
			baseText = File.ReadAllText ("Assets/CsvFiles/level" + levelString + "-" + layerString + ".csv");
			layerString = "";
			lines = baseText.Split("\n"[0]);
			zChange = 0;

			//1st for loop is for which line of text too use
			for (int z = 0; z < lines.Length; z++) 
			{
				//trims the current line into seperate values
				lineData = (lines [z].Trim ()).Split ("," [0]);
				xChange = 0;
				zChange += objectSize;
				//2nd Nested for loop reads each value in the line selected in the 1st for loop
				for (int x = 0; x < lineData.Length; x++) 
				{
					if (layer == 1) {
						switch (lineData [x]) 
						{
						case "SG":
							currentObject = sandGround;
							break;
						case "AG":
							currentObject = reefGround;
							break;
						case "RG":
							currentObject = atlantisGround;
							break;
						default:
							currentObject = null;
							break;
						}
						if(currentObject != null)
							Instantiate (currentObject, new Vector3 (xChange, transform.position.y, zChange), Quaternion.identity);
					}

					if (layer == 2) {
						switch (lineData [x]) 
						{
						case "#":
							currentObject = wall;
							break;
						case "P":
							currentObject = player;
							break;
						default:
							currentObject = null;
							break;
						}
						if(currentObject != null)
							Instantiate (currentObject, new Vector3 (xChange, transform.position.y + objectSize, zChange), Quaternion.identity);
					}
					xChange += objectSize;
				}
			}
		}
	}
}