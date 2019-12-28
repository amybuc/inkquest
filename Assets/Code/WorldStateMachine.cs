using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldStateMachine : MonoBehaviour {

    public DateTime stateRefreshTime;
    public List<WorldState> stateDatabase;

    public ItemDatabase itemDatabase;

	public Town testTown;

    //public Town testTown;

    [HideInInspector]
    public string rarity;



    // Use this for initialization
    void Start () {

		//Debug.Log("Start - Towns active state is " + testTown.activeState[0].stateName);
		//Debug.Log("Finding state " + FindStateByName("bounty crop").stateName + " and it has a modifier of " + FindStateByName("bounty crop").modifierType);

		RefreshNewTownInventories();
		/*
		if (verifyAllTownsHaveStates() == true)
		{
			
		}
		*/
		


	}
	
	// Update is called once per frame
	void Update () {

		/*
        if (System.DateTime.Now == stateRefreshTime)
        {
            RefreshTimer();
            
        }
        */

	}

	public bool verifyAllTownsHaveStates()
	{
		GameObject[] allTowns = GameObject.FindGameObjectsWithTag("TOWN");
		foreach (GameObject town in allTowns)
		{
			if (town.GetComponent<Town>().activeState[0] == null)
			{
				Debug.Log("WSM :: Failed Verification - one or more towns do not have an active state. Error log: " + town.GetComponent<Town>().townName);
				return false;
			}

			else
			{
		
			}
		}

		return true;

	}


	void updateTownStates(bool firstTimeRun)
	{
		Debug.Log("WSM :: update Town states run!");

		GameObject[] allTowns = GameObject.FindGameObjectsWithTag("TOWN");
		Debug.Log("Amount of towns: " + allTowns.Length);
		foreach (GameObject town in allTowns)
		{
			Debug.Log("WSM :: Town to assign a state to is: " + town.GetComponent<Town>().townName);
			//RANDOMISER
			//First, lets descide whether we're changing our current state!

			if (firstTimeRun == false && UnityEngine.Random.Range(0, 10) >= 6)
			{
				Debug.Log("The state will remain the same");
				//State will remain the same!
			}
			else
			{
				//State is going to change!
				int randomiser = UnityEngine.Random.Range(0, 100);

				if (randomiser >= 0 && randomiser <= 40)
				{
					addStateToTown("normal", town.GetComponent<Town>());
					//WorldState state = FindStateByName("normal");
					Debug.Log("WSM ::" + town.GetComponent<Town>().townName + " is being given a status of " + "normal");
					//town.GetComponent<Town>().activeState[0] = state;
				}
				if (randomiser >= 41 && randomiser <= 60)
				{
					addStateToTown("bounty crop", town.GetComponent<Town>());
					//WorldState state = FindStateByName("bounty crop");
					Debug.Log("WSM ::" + town.GetComponent<Town>().townName + " is being given a status of " + "bounty crop");
					//town.GetComponent<Town>().activeState[0] = state;
				}
				if (randomiser >= 61 && randomiser <= 80)
				{
					addStateToTown("famine", town.GetComponent<Town>());
					//WorldState state = FindStateByName("famine");
					Debug.Log("WSM ::" + town.GetComponent<Town>().townName + " is being given a status of " + "famine");
					//town.GetComponent<Town>().activeState[0] = state;
				}
				if (randomiser >= 61 && randomiser <= 80)
				{
					addStateToTown("at war", town.GetComponent<Town>());
					//WorldState state = FindStateByName("at war");
					Debug.Log("WSM ::" + town.GetComponent<Town>().townName + " is being given a status of " + "at war");
					//town.GetComponent<Town>().activeState[0] = state;
				}
				if (randomiser >= 81 && randomiser <= 90)
				{
					addStateToTown("pacifist", town.GetComponent<Town>());
					//WorldState state = FindStateByName("pacifist");
					Debug.Log("WSM ::" + town.GetComponent<Town>().townName + " is being given a status of " + "pacifist");
					//town.GetComponent<Town>().activeState[0] = state;
				}


			}

		}


		RefreshNewTownInventories();
	}

    void RefreshTimer()
    {
        //First, reset the timer to a new time
       //stateRefreshTime = System.DateTime.Now.AddMinutes(UnityEngine.Random.Range(6, 12));

    }

    public void RefreshNewTownInventories()
    {
        Debug.Log("L O G :: RefreshNewTownInventories Run");
        Debug.Log("SANITY CHECK - verify all towns for states returns " + verifyTownsHaveStates());
        //Refresh all town inventories based on each town's active condition!

        GameObject[] allTowns = GameObject.FindGameObjectsWithTag("TOWN");

        foreach (GameObject _town in allTowns)
        {
			//Debug.Log("TEST :: Town object is " + _town.name);
			//Debug.Log("Calculating state effect for town " + _town.GetComponent<Town>().townName);

			//testTown.activeState[0] = FindStateByName("bounty crop"); //BIG DEBUG, DONT FORGET TO REMOVE

			//Debug.Log("The town's active state is " + _town.GetComponent<Town>().activeState[0].stateName);

			if (_town.GetComponent<Town>() != null)
            {
                _town.GetComponent<Town>().shopItems.Clear(); //Clear the existing list

                if (_town.GetComponent<Town>().activeState[0].stateName != null)
                {
                    //Check if the active condition affects the town inventory
                    if (_town.GetComponent<Town>().activeState[0].affectsTownInventory == true)
                    {
                        if (_town.GetComponent<Town>().activeState[0].affectToTownInventory == "include")
                        {
                            _town.GetComponent<Town>().shopItems = returnSomeObjects(_town.GetComponent<Town>().activeState[0].affectedTag, true);
                        }
                        else if (_town.GetComponent<Town>().activeState[0].affectToTownInventory == "exclude")
                        {
                            _town.GetComponent<Town>().shopItems = returnSomeObjects(_town.GetComponent<Town>().activeState[0].affectedTag, false);
                        }
                    }
                    else // Just do a non-modified randommisation of objects!
                    {
                        _town.GetComponent<Town>().shopItems = returnSomeObjects("none", false);
                    }
                }
                else
                {
                    Debug.Log("The Town has no active State :(");
                }


            }
            else
            {
                Debug.Log("There is no Town component on that gameobject!");
                return;
            }


        }




    }

    List<Item> returnSomeObjects(string tag, bool include)
    {
        Debug.Log("L O G :: returnSomeObjects Run");
        //

        //Work out how many items will be in this inventory
        int inventorySize = UnityEngine.Random.Range(5, 12);


        List<Item> outputItems = new List<Item>(); 


        for (int i = 0; i < inventorySize; i++)
        {
            int randomiser = UnityEngine.Random.Range(0, 100);
            //Debug.Log("1. The raritychecker numer is " + randomiser);

            if (randomiser >= 0 && randomiser <= 85)
            {
                //Give the town inventory a common item
                rarity = "common";
            }
            else if (randomiser >= 86 && randomiser <= 95)
            {
                //Give the town inventory an uncommon item
                rarity = "uncommon";
            }
            else if (randomiser >= 96 && randomiser <= 99)
            {
                //Give the town inventory a rare item
                rarity = "rare";
            }
            else if (randomiser == 100)
            {
                //Give the town inventory a mythical item
                rarity = "mythical";
            }

            //First, troll the whole inventory for every item with the rarity you want

            List<Item> possibleItems = itemDatabase.GetAllItemsOfRarity(rarity);

            if (possibleItems.Count > 0)
            {

                //Now, pick a random item from out list of correctly rare items
                int itemnum = UnityEngine.Random.Range(0, possibleItems.Count);

                //Ok, we have our item num!! Now, we need to make sure we're supposed to/allowed to have this item in this town
                if (tag != "none")
                {
                    if (include = true)
                    {
                        if (possibleItems[itemnum].tag == tag)
                        {
                            outputItems.Add(possibleItems[itemnum]);
                            //Debug.Log(possibleItems[itemnum].itemName + "is being added to town inventory because it has the tag " + tag);
                        }
                        else //the tag doesnt equal the needed tag! Keep shuffling
                        {
                            while (possibleItems[itemnum].tag != tag)
                            {
                                itemnum = UnityEngine.Random.Range(0, possibleItems.Count);
                            }

                            outputItems.Add(possibleItems[itemnum]);
                            //Debug.Log(possibleItems[itemnum].itemName + "is being added to town inventory because it has the tag " + tag);
                        }
                    }

                    if (include == false)
                    {
                        if (possibleItems[itemnum].tag != tag)
                        {
                            outputItems.Add(possibleItems[itemnum]);
                            //Debug.Log(possibleItems[itemnum].itemName + "is being added to town inventory because it doesn't have the tag " + tag);
                        }
                        else
                        {
                            while (possibleItems[itemnum].tag == tag)
                            {
                                itemnum = UnityEngine.Random.Range(0, possibleItems.Count);
                            }

                            outputItems.Add(possibleItems[itemnum]);
                            //Debug.Log(possibleItems[itemnum].itemName + "is being added to town inventory because it doesn't have the tag " + tag);
                        }
                    }
                }
                else
                {
                    outputItems.Add(possibleItems[itemnum]);
                    //Debug.Log(possibleItems[itemnum].itemName + "is being added to town inventory because no tag was defined");

                }
            }
            else //No items in possibleitems
            {
                //Debug.Log("Possible items has no items in it");
            } 





        }

        return outputItems;
    } 

    public void addStateToTown(string state, Town town)
    {
		town.activeState.Clear();

        foreach(WorldState _state in stateDatabase)
        {
            if (_state.stateName == state)
            {
                town.activeState.Add(_state);
            }
        }
    }

    public WorldState FindStateByName(string statename)
    {
        foreach (WorldState _state in stateDatabase)
        {
            if (_state.stateName == statename)
            {
				Debug.Log("WSM :: FindStateByName :: returning " + _state.stateName);
				return _state;
            }

        }
		Debug.Log("WSM :: FindStateByName :: Couldn't find state in database :c");
		return null;

    }

    public bool verifyTownsHaveStates()
    {
        //This is mainly for debugging - returns true if all towns in game have been assigned a state correctly
        GameObject[] allTowns = GameObject.FindGameObjectsWithTag("TOWN");

        foreach (GameObject _town in allTowns)
        {
            if (_town.GetComponent<Town>().activeState[0].stateName == null)
            {
                Debug.Log("verifyTownsHaveStates has failed - " + _town.GetComponent<Town>().townName + " has no state assigned");
                return false;
            }
        }
        return true;

    }




    void buildStateDatabase()
    {

        Debug.Log("L O G :: BuildStateDatabase Run");

        WorldState normal = new WorldState();
        normal.stateName = "normal";
        normal.modifier = 0;
        normal.affectsBuySell = "none";
        normal.modifierType = "none";
        normal.affectsTags = false;
        normal.affectsTownInventory = false;
        stateDatabase.Add(normal);

        WorldState famine = new WorldState();
        famine.stateName = "famine";
        famine.modifier = 40;
        famine.affectsBuySell = "buyprice";
        famine.modifierType = "addition";
        famine.affectsTags = true;
        famine.affectedTag = "food";
        famine.affectsTownInventory = true;
        famine.affectToTownInventory = "exclude";
        famine.inventoryAffectedTag = "food";
        stateDatabase.Add(famine);

        WorldState bountyCrop = new WorldState();
        bountyCrop.stateName = "bounty crop";
        bountyCrop.modifier = 40;
        bountyCrop.affectsBuySell = "sellprice";
        bountyCrop.modifierType = "subtraction";
        bountyCrop.affectsTags = true;
        bountyCrop.affectedTag = "food";
        bountyCrop.affectsTownInventory = true;
        bountyCrop.affectToTownInventory = "include";
        bountyCrop.inventoryAffectedTag = "food";
        stateDatabase.Add(bountyCrop);

		WorldState atWar = new WorldState();
		atWar.stateName = "at war";
		atWar.modifier = 200; //To be changed to 50 later
		atWar.affectsBuySell = "sellprice";
		atWar.modifierType = "addition";
		atWar.affectsTags = true;
		atWar.affectedTag = "weapon";
		atWar.affectsTownInventory = false;
		atWar.affectToTownInventory = "null";
		atWar.inventoryAffectedTag = "null";
		stateDatabase.Add(atWar);

		WorldState pacifist = new WorldState();    //This one will need some thought - it affects the town's relationship - im gonna make a relationship function somewhere to check for this - probably when you open the town menu, thats when itll run a check to see if you have any weapons and deduct relationship accordingly.
		pacifist.stateName = "pacifist";
		pacifist.modifier = 200; //To be changed to 50 later
		pacifist.affectsBuySell = "null";
		pacifist.modifierType = "null";
		pacifist.affectsTags = false;
		pacifist.affectedTag = "null";
		pacifist.affectsTownInventory = true;
		pacifist.affectToTownInventory = "exclude";
		pacifist.inventoryAffectedTag = "weapon";
		stateDatabase.Add(pacifist);

		//"at war"


		//Passive States

		WorldState coastal = new WorldState();
        coastal.stateName = "coastal";
        coastal.modifier = 40;
        coastal.affectsBuySell = "sellprice";
        coastal.modifierType = "subtraction";
        coastal.affectsTags = false;
        coastal.affectsTownInventory = true;
        coastal.affectToTownInventory = "include";
        coastal.inventoryAffectedTag = "coastal";
        stateDatabase.Add(coastal);




    }

    public void Awake()
    {
        buildStateDatabase();
		updateTownStates(true);
	}
}
