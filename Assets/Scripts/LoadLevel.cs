using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadLevel : MonoBehaviour {
	//GameObjects to add to inspector/layers
	public GameObject wall;
	public GameObject player;
	public GameObject sandGround;
	public GameObject reefGround;
	public GameObject atlantisGround;
    public GameObject BoulderObstacle;
    public GameObject PressuePlate;
    public GameObject SandGroundPortal;
	public GameObject grass;
    public GameObject SandBoulderHole;
    public GameObject GroundTrap;

    public int level;

	GameObject currentObject;
	GameObject stringObject;
	string baseText;
	string[] lines;
	string[] lineData;
	float xChange;
	float zChange;
	int layer;
	string levelString;
	string layerString;


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
			StreamReader reader = new StreamReader (new MemoryStream ((Resources.Load ("Level" + levelString + "-" + layerString) as TextAsset).bytes));
			baseText = reader.ReadToEnd();
			layerString = "";
			lines = baseText.Split("\n"[0]);

			//reset z axis
			zChange = 0;

			//1st Nested for loop is for which line of text too use
			for (int z = 0; z < lines.Length; z++) 
			{
				//trims the current line into seperate values
				lineData = (lines [z].Trim ()).Split ("," [0]);

				//Reseting x for new line and moving z axis to apply the next line
				xChange = 0;
				zChange -= 1f;
				//2nd Nested for loop reads each value in the line selected in the 1st for loop
				for (int x = 0; x < lineData.Length; x++) 
				{
					//Follow implementation below to add new objects
					//Layer 1 is all of the layer 1 objects (floors mainly)
					//Only worry about adding in a new case, creating a public variable at the start of this script
					//Then adding the required object to the public gameObject variable in the inspector
					if (layer == 1) 
					{
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
                        case "SP":
                            currentObject = SandGroundPortal;
                            break;
                        case "SBH":
                            currentObject = SandBoulderHole;
                                break;
                        case "#":
                            currentObject = wall;
                            break;
                        case "GT":
                            currentObject = GroundTrap;
                            break;
                        default:
							currentObject = null;
							break;
                            



                        }
						if (currentObject != null) 
						{
							Instantiate (currentObject, new Vector3 (xChange, transform.position.y, zChange), Quaternion.identity);
						}
					}

					//Layer 2 is for the walls,player,enemies etc..
					if (layer == 2) 
					{
						switch (lineData [x]) 
						{
						case "#":
							currentObject = wall;
							break;
						case "P":
							currentObject = player;
							break;
                        case "BO":
                            currentObject = BoulderObstacle;
                            break;
						case "G":
							currentObject = grass;
							break;
                        case "PP":
                            currentObject = PressuePlate;
                            break;
                            default:
							currentObject = null;
							break;
						}
						if (currentObject != null) 
						{
							Instantiate (currentObject, new Vector3 (xChange, transform.position.y + 1f, zChange), Quaternion.identity);
						}
					}

					//move x axis to the next instantiate location
					xChange += 1f;
				}
			}
		}
	}
}