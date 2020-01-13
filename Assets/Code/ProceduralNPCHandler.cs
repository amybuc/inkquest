using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralNPCHandler : MonoBehaviour {
	/*
	public DialogueStringDatabase dialogueStringDataBase;

	public GameObject minYMaxX;
	public GameObject maxYMinX;

	public float MaxY;
	public float MinY;

	public float MaxX;
	public float MinX;

	public bool colCheck = false;
	bool isValidPos = false;

	// Use this for initialization
	void Start () {

		MaxY = maxYMinX.transform.position.y;
		MinY = minYMaxX.transform.position.y;

		MaxX = minYMaxX.transform.position.x;
		MinX = maxYMinX.transform.position.x;


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void resetAndRandomiseNPCs()
	{
		//init class - runs all other functions in order to clear all current NPCs, then will create a random number of new NPCs and place them randomly, with randomly generated dialogue.
	}

	public void clearActiveNPCs()
	{
		//Clear all current NPCs, in preparation for adding a new set of randomised NPCs
		GameObject[] currentNpcs = GameObject.FindGameObjectsWithTag("NPC");
		foreach (GameObject npc in currentNpcs)
		{
			GameObject.Destroy(npc);
		}
	}

	public Vector3 findRandomXYPosition()
	{
		//Finds a random point in X and Y space that is within the bounds of the environment, and is not colliding with a collider

		float x;
		float y;

		do
		{
			x = Random.Range(MinX, MaxX);
			y = Random.Range(MinY, MaxY);

			colCheck = Physics2D.OverlapCircle(new Vector2(x, y), 5);

			if (colCheck == true)
			{
				isValidPos = false;
			}
			else if (colCheck == false)
			{
				isValidPos = true;
			}

		} while (isValidPos == false);

		isValidPos = false;
		return new Vector3(x, y, 25);

	}

	public string[] generateNPCText()
	{
		//Returns dialogue for a randomly generated NPC - feeds from the currently active states of towns. Also fills the dialogue template in with relevant information, ie, town name, etc.

		//0. First - is the NPC going to give generic dialogue or a rumour?
		if (Random.Range(1, 10) >= 4)
		{
			//dialogue will be rumour
		}
		else
		{
			//dialogue will be generic
			int dialogue = Random.Range(0, dialogueStringDataBase.genericDialogue.Count-1);
			
			
		}
		
		

		//1. Find a random Town
		//2. Find that towns state is (if its normal, will just give a generic rumour)
		//3. Generate a random string from the string database, of that state type (lets make a function within dialoguestringdatabase for this, that takes input of the state name)
		//4. Fill it - replace $$$ with the town name, and split the string at any / symbols.
		//5. return a string array
	}

	public GameObject createeNewNPC()
	{
		//returns an instantiated NPC, with randomised art, and places an NPC component on the gameobject, ready to be filled with dialogue/information. Also give object the tag 'NPC'
	}


	//Possibility for expansion - a randomly generated quest system?
	*/
}
