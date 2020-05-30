using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralNPCHandler : MonoBehaviour {
	
	public DialogueStringDatabase dialogueStringDataBase;

	public GameObject npcPrefab;

	public GameObject minYMaxX;
	public GameObject maxYMinX;

	public float MaxY;
	public float MinY;

	public float MaxX;
	public float MinX;

	public bool colCheck = false;
	bool isValidPos = false;

	public List<string> NPCimages;

	// Use this for initialization
	void Start () {

		buildNPCImagesDatabase();

		MaxY = maxYMinX.transform.position.y;
		MinY = minYMaxX.transform.position.y;

		MaxX = minYMaxX.transform.position.x;
		MinX = maxYMinX.transform.position.x;

		//resetAndRandomiseNPCs();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void resetAndRandomiseNPCs()
	{
        Debug.Log("resetAndRandomiseNPCs() run!");

		//init class - runs all other functions in order to clear all current NPCs, then will create a random number of new NPCs and place them randomly, with randomly generated dialogue.
		clearActiveNPCs();

		int NPCnum = Random.Range(5, 10);
		//Debug.Log("Going to be making " + NPCnum + " number of NPCs!");

		for (int i = 0; i < NPCnum; i++)
		{
			//Debug.Log("RANDOMISIGN NPCS - for loop running!!");
			GameObject newNPC = createeNewNPC();
			newNPC.transform.position = findRandomXYPosition();
			newNPC.GetComponent<NPC>().dialogue = generateNPCText();
		}


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

        //remove this below line later
        isValidPos = true;

		do
		{
			x = Random.Range(MinX, MaxX);
			y = Random.Range(MinY, MaxY);

            //THIS IS THE POINT AT WHICH WE NEED TO CHECK ITS NOT BEING INSTANTIATED OVER A COLLIDER - currently its not working, so put this on the to-do list

            /*

			colCheck = Physics2D.OverlapCircle(new Vector2(x, y), 2);

			if (colCheck == true)
			{
				isValidPos = false;
			}
			else if (colCheck == false)
			{
				isValidPos = true;
			}
			*/

		} while (isValidPos == false);

		isValidPos = false;
		return new Vector3(x, y, 25);

	}

	public string[] generateNPCText()
	{
        //Returns dialogue for a randomly generated NPC - feeds from the currently active states of towns. Also fills the dialogue template in with relevant information, ie, town name, etc.

        //1. Find a random Town
        GameObject[] allTowns = GameObject.FindGameObjectsWithTag("TOWN");
        int selectedTown = Random.Range(0, allTowns.Length - 1);
        Town town = allTowns[selectedTown].GetComponent<Town>();

        //0. First - is the NPC going to give generic dialogue or a rumour?
        //if (Random.Range(1, 10) >= 4)
        if (Random.Range(1, 10) >= 1)
		{
			//Dialogue will be rumour

			string rawdialogue = dialogueStringDataBase.returnRandomRumour(town.activeState[0].stateName);

            if (rawdialogue.Contains("$$$"))
            {
                rawdialogue = rawdialogue.Replace("$$$", town.townName);

            }
            if (rawdialogue.Contains("/"))
			{
				string[] parsedDialogue = rawdialogue.Split(char.Parse("/"));
				return parsedDialogue;

			}
            if (!rawdialogue.Contains("$$$") && !rawdialogue.Contains("/"))
			{
				string[] parsedDialogue = new string[1];
                //Debug.Log("Raw dialogue is " + rawdialogue);
				parsedDialogue[0] = rawdialogue;
                //Debug.Log("parsedDialogue[0] is " + parsedDialogue[0]);
				return parsedDialogue;
			}
            Debug.Log("GENERATE NPC TEXT HAS FAILED, NO DIALOGUE RETURNED");
            return null;
		}
		else
		{
			//dialogue will be generic
			int dialogueint = Random.Range(0, dialogueStringDataBase.genericDialogue.Count-1);
            string dialogue = dialogueStringDataBase.genericDialogue[dialogueint];

            if (dialogue.Contains("$$$"))
            {
                dialogue = dialogue.Replace("$$$", town.townName);

            }
            if (dialogue.Contains("/"))
			{
				string[] dialoguearray = dialogue.Split(char.Parse("/"));
				return dialoguearray;
			}
            if (!dialogue.Contains("$$$") && !dialogue.Contains("/"))
            {
				string[] parsedDialogue = new string[1];
				parsedDialogue[0] = dialogue;
				return parsedDialogue;
			}
            Debug.Log("GENERATE NPC TEXT HAS FAILED, NO DIALOGUE RETURNED");
            return null;

        }
	}

	public GameObject createeNewNPC()
	{
		GameObject newNPC = Instantiate(npcPrefab);
		newNPC.tag = "NPC";
		//Debug.Log("New NPC being instantiated!!");

		//This would be a good place to put Quest info, item info, etc

		//Randomise Art
		int randomiser = Random.Range(0, NPCimages.Count - 1);
		newNPC.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(NPCimages[randomiser]);

		return newNPC;


		//returns an instantiated NPC, with randomised art, and places an NPC component on the gameobject, ready to be filled with dialogue/information. Also give object the tag 'NPC'
	}

	public void buildNPCImagesDatabase()
	{
		NPCimages.Add("NPCImages/Art_NPC_generic01");
		NPCimages.Add("NPCImages/Art_NPC_generic02");
		NPCimages.Add("NPCImages/Art_NPC_generic03");
		NPCimages.Add("NPCImages/Art_NPC_generic04");
		NPCimages.Add("NPCImages/Art_NPC_generic05");
		NPCimages.Add("NPCImages/Art_NPC_generic06");
		NPCimages.Add("NPCImages/Art_NPC_generic07");
		NPCimages.Add("NPCImages/Art_NPC_generic08");
		NPCimages.Add("NPCImages/Art_NPC_generic09");
		NPCimages.Add("NPCImages/Art_NPC_generic10");
		NPCimages.Add("NPCImages/Art_NPC_generic11");
		NPCimages.Add("NPCImages/Art_NPC_generic12");
		NPCimages.Add("NPCImages/Art_NPC_generic13");
		NPCimages.Add("NPCImages/Art_NPC_generic14");
	}


	//Possibility for expansion - a randomly generated quest system?
	
}
