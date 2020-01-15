using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStringDatabase : MonoBehaviour {

	//NPC strings
    public List<string> genericDialogue;
    public List<string> givingDialogue;
    public List<string> buyingDialogue;

	//Rumour Strings
    public List<string> genericRumourStrings;
    public List<string> pacifistTownRumourStrings;
	public List<string> famineTownRumourStrings;
	public List<string> bountyCropTownRumourStrings;
	public List<string> atWarTownRumourStrings;

	//Town Status string lists
	public List<string> genericTownStatusStrings;
	public List<string> coastalTownStatusStrings;
	public List<string> forestTownStatusStrings;
	public List<string> sandsTownStatusStrings;

	public List<string> highRelTownStatusStrings;
	public List<string> medRelTownStatusStrings;
	public List<string> lowRelTownStatusStrings;

	public List<string> noneTownStatusStrings;
	public List<string> pacifistTownStatusStrings;
	public List<string> famineTownStatusStrings;
	public List<string> bountyCropTownStatusStrings;
	public List<string> atWarTownStatusStrings;

	/*
	//LEGEND

	/ - this is a split in the dialogue. It means the string will need to be broken up when made into an array.
	$$$ - this is a placeholder - when filling in the dialogue, the name of the town being spoken of will go here.

	*/

	// Use this for initialization
	void Start () {

		

	}

    private void Awake()
    {
        updateGenericDialogue();
        updateGivingDialogue();

        updateGenericRumourStrings();
        updatePacifistTownRumourStrings();
        updatefamineTownRumourStrings();
        updatebountyCropTownRumourStrings();
        updateAtWarTownRumourStrings();


        updateGenericTownStatusStrings();
        updatecoastalTownStatusStrings();
        updateforestTownStatusStrings();
        updatesandsTownStatusStrings();
        updatehighRelTownStatusStrings();
        updatemedRelTownStatusStrings();
        updatelowRelTownStatusStrings();
        updatenoneTownStatusStrings();
        updatepacifistTownStatusStrings();
        updatefamineTownStatusStrings();
        updatebountyCropTownStatusStrings();
        updateatWarTownStatusStrings();
    }

    // Update is called once per frame
    void Update () {




	}

	//FUNCTIONS


	public string generateTownStatus(Town town)
	{
		string parta = null;
		string partb = null;
		string partc = null;
		string finalstring;

		//first part - location specific
		if (town.townLocation == "coastal")
		{
			Debug.Log("DSD :: Town is on the coast!");
			parta = coastalTownStatusStrings[Random.Range(0, coastalTownStatusStrings.Count - 1)];
		}
		else if (town.townLocation == "forest")
		{
			Debug.Log("DSD :: Town is on the coast!");
			parta = forestTownStatusStrings[Random.Range(0, forestTownStatusStrings.Count - 1)];
		}
		else if (town.townLocation == "desert")
		{
			parta = sandsTownStatusStrings[Random.Range(0, sandsTownStatusStrings.Count - 1)];
		}

		//second part - status specific
        //First, check that there is actually an active state on this town

        if (town.activeState[0].stateName != null)
        {
			if (town.activeState[0].stateName == "normal")
			{
				partb = noneTownStatusStrings[Random.Range(0, noneTownStatusStrings.Count - 1)];
			}
            if (town.activeState[0].stateName == "pacifist")
            {
                partb = pacifistTownStatusStrings[Random.Range(0, pacifistTownStatusStrings.Count - 1)];
            }
            else if (town.activeState[0].stateName == "famine")
            {
                partb = famineTownStatusStrings[Random.Range(0, famineTownStatusStrings.Count - 1)];
            }
            else if (town.activeState[0].stateName == "bounty crop")
            {
                partb = bountyCropTownStatusStrings[Random.Range(0, bountyCropTownStatusStrings.Count - 1)];
            }
            else if (town.activeState[0].stateName == "at war")
            {
                partb = atWarTownStatusStrings[Random.Range(0, atWarTownStatusStrings.Count - 1)];
            }
        }
        else
        {
            Debug.Log("There's no active state on " + town.townName);
        }

		

		//third part - relationship specific
		if (town.relationship >= 0 && town.relationship <= 35)
		{
			partc = lowRelTownStatusStrings[Random.Range(0, lowRelTownStatusStrings.Count - 1)];
		}
		if (town.relationship >= 36 && town.relationship <= 75)
		{
			partc = medRelTownStatusStrings[Random.Range(0, medRelTownStatusStrings.Count - 1)];
		}
		if (town.relationship >= 76)
		{
			partc = highRelTownStatusStrings[Random.Range(0, highRelTownStatusStrings.Count - 1)];
		}

		if (parta != null && partb != null && partc != null)
		{
			finalstring = parta + "\n" + partb + "\n" + partc;
			return finalstring;
		}
		else
		{
			Debug.Log("Generate town status = Something was null when composing town status message - debugging time!");
			return null;
		}

		

	}

	public string returnRandomRumour(string statename)
	{

		Debug.Log("NPC GENERATION :: Running returnRandomRumour with state " + statename);

		if (statename == "normal")
		{
			int randomiser = Random.Range(0, genericRumourStrings.Count);
            Debug.Log("The amount of strings in this particular database is " + genericRumourStrings.Count);
			Debug.Log("NPC GENERATION :: The random number to detirmine which dialogue to return is " + randomiser);
			return genericRumourStrings[randomiser];
		}
		else if (statename == "famine")
		{
			int randomiser = Random.Range(0, famineTownRumourStrings.Count);
            Debug.Log("The amount of strings in this particular database is " + famineTownRumourStrings.Count);
            Debug.Log("NPC GENERATION :: The random number to detirmine which dialogue to return is " + randomiser);
			return famineTownRumourStrings[randomiser];
		}
		else if (statename == "bounty crop")
		{
			int randomiser = Random.Range(0, bountyCropTownRumourStrings.Count);
            Debug.Log("The amount of strings in this particular database is " + bountyCropTownRumourStrings.Count);
            Debug.Log("NPC GENERATION :: The random number to detirmine which dialogue to return is " + randomiser);
			return bountyCropTownRumourStrings[randomiser];
		}
		else if (statename == "at war")
		{
			int randomiser = Random.Range(0, atWarTownRumourStrings.Count);
            Debug.Log("The amount of strings in this particular database is " + atWarTownRumourStrings.Count);
            Debug.Log("NPC GENERATION :: The random number to detirmine which dialogue to return is " + randomiser);
			return atWarTownRumourStrings[randomiser];
		}
		else if (statename == "pacifist")
		{
			int randomiser = Random.Range(0, pacifistTownRumourStrings.Count);
            Debug.Log("The amount of strings in this particular database is " + pacifistTownRumourStrings.Count);
            Debug.Log("NPC GENERATION :: The random number to detirmine which dialogue to return is " + randomiser);
			return pacifistTownRumourStrings[randomiser];
		}
		else
		{
			Debug.Log("Something wrong with returnRandomRumour, no state was fed into it");
			return null;
		}
	}




	
	//                                                                                    STRING STORAGE

	//NPC DIALOGUE

    public void updateGenericDialogue()
    {
        genericDialogue.Add("I've been travelling some time now! Does the road look clear ahead?");
        genericDialogue.Add("Sick kid, huh? Well, I hope it's not contagious, because you'd have infected the whole world by now.");
        genericDialogue.Add("I stubbed my toe on a rock back there!!");
		genericDialogue.Add("I'm planning on travelling all along the northern coastline some day. Have you ever been? / I hear the fish are saltier and juicier, and the people are merry and welcoming.");
	}

    public void updateGivingDialogue()
    {
        givingDialogue.Add("hehe");
    }

	//RUMOUR DIALOGUE

	public void updateGenericRumourStrings()
	{
        Debug.Log("updateGenericRumourStrings() is running!");
		genericRumourStrings.Add("They say there are cats who went mad in the Eldar Woods somewhere. They also say that they're plotting to revive the old ways. / I mean, I don't believe that kind of stuff, it's just scary stories for kids - right?");
		genericRumourStrings.Add("I've heard that the towns along the coast are known for their fish - I bet cats living in the sands would give anything to try it!");
		genericRumourStrings.Add("The sands are a pretty unforgiving kind of place, have you heard?");
		genericRumourStrings.Add("$$$ is maybe the most beautiful place i've ever been to!");
	}

	public void updatePacifistTownRumourStrings()
	{
        Debug.Log("updatePacifistTownRumourStrings() is running!");
        pacifistTownRumourStrings.Add("Have you heard? $$$ have declared peace in their walls - anyone trading weapons around there best be wary.");
		pacifistTownRumourStrings.Add("$$$ has been declared a pacifist city - what does that mean, I wonder?");
		pacifistTownRumourStrings.Add("I'm considering moving to $$$ - I want my kittens to grow up in a peaceful, pacifist city.");
		pacifistTownRumourStrings.Add("I'd hate to be a warrior in $$$ now they've declared peace - anyone with a weapon around there best be wary.");
	}

    public void updatefamineTownRumourStrings(){
        Debug.Log("updatefamineTownRumourStrings() is running!");
        famineTownRumourStrings.Add("I've heard tell that $$$ have had a disappointing crop - it'll be tough getting food in mouths in those parts.");
        famineTownRumourStrings.Add("I'm on my way to visit my mother, in $$$. I've heard they're facing a food crisis, so I'm bringing her some supplies / I do hope they manage to get some food to those poor, poor people.");
    }

    public void updatebountyCropTownRumourStrings()
    {
        Debug.Log("updatebountyCropTownRumourStrings() is running!");
        bountyCropTownRumourStrings.Add("Feasts on tonight at $$$! I've heard they had a bumper crop, I'm on my way to go and buy some potatoes!");
        bountyCropTownRumourStrings.Add("Did you know that $$$ is experiencing a bountiful crop at the moment? Those lucky folks, the bread from $$$ is the best in the world!");
		bountyCropTownRumourStrings.Add("I'm on my way to $$$! I've heard they've had a plentiful crop, I'm off to stock up my pantry.");
	}

    public void updateAtWarTownRumourStrings() //Eventually, add a secondary $$$ value to detirmine who theyre going to war against
    {
        Debug.Log("updateAtWarTownRumourStrings() is running!");
        atWarTownRumourStrings.Add("You should consider steering clear of $$$, friend! I've heard the torches are lit and the weapons sharpened for war there.");
        atWarTownRumourStrings.Add("Have you heard? $$$ is at war!");
        atWarTownRumourStrings.Add("I'm off to $$$ to make my fortune as a soldier - have you heard? They're going to war!");
    }

    //TOWN STATUS STRINGS


    public void updateGenericTownStatusStrings()
	{
		genericTownStatusStrings.Add("There's a sweetness to the air today, it seems like the whole town is enjoying a relaxed day.");
        genericTownStatusStrings.Add("There seem to be more people in the streets today - you wonder if there's an event happening.");
        genericTownStatusStrings.Add("T");
    }

	public void updatecoastalTownStatusStrings()
	{
		coastalTownStatusStrings.Add("There's a chill wind blowing in from the coast - seagulls are calling, struggling against the breeze.");
        coastalTownStatusStrings.Add("Everything in the town feels salty and damp, theres a constant sea spray from the rocky coast.");
    }

	public void updateforestTownStatusStrings()
	{
		forestTownStatusStrings.Add("The forest beyond the walls is quiet today, though you can see the shape of something moving around through the trees. The city gates are firmly closed.");
        forestTownStatusStrings.Add("This is a town enveloped in the lush green of the forest. Outside the walls, insects and birds call ceaselessly.");
    }

	public void updatesandsTownStatusStrings()
	{
		sandsTownStatusStrings.Add("It seems a sandstorm just blew through here - the people are poking their heads out of their shelters, and shifting thick layers of sand from the roofs of their homes. The air is dry here.");
        sandsTownStatusStrings.Add("A sandstorm looks to be blowing in from the north - the people seem to be preparing their homes for the storm.");
    }




	public void updatehighRelTownStatusStrings()
	{
		highRelTownStatusStrings.Add("The people see you coming and wave. You see some familiar faces among the smiling crowd. This is a town that knows and loves you.");
		highRelTownStatusStrings.Add("This city is welcoming, and it's people smile as you pass them by - you are a familiar face here.");
	}

	public void updatemedRelTownStatusStrings()
	{
		medRelTownStatusStrings.Add("The people are impartial to you, and pay you no mind. Perhaps they are unfamiliar with you yet.");
        medRelTownStatusStrings.Add("Perhaps you haven't made enough of a name for yourself in this city yet - the people don't know you too well.");
    }

	public void updatelowRelTownStatusStrings()
	{
		lowRelTownStatusStrings.Add("One cat spits at your feet as you pass, and others glower and mutter. It seems you are not welcome here.");
		lowRelTownStatusStrings.Add("There's a hateful tone to the voice of those you speak to here - clearly they are not fond of you.");
	}




	public void updatenoneTownStatusStrings()
	{
		noneTownStatusStrings.Add("The town seems to be fairly normal at the moment - nothing much has happened here lately.");
        noneTownStatusStrings.Add("The is nothing of note about this town, things seem to be business-as-usual.");
    }

	public void updatepacifistTownStatusStrings()
	{
		pacifistTownStatusStrings.Add("There are posters and signs in the street advocating peace - this is a pacifist city.");
        pacifistTownStatusStrings.Add("You see town guards doing weapon raids, ensuring the town stays free of weaponry - there seems to be a ban in place.");
    }

	public void updatefamineTownStatusStrings()
	{
		famineTownStatusStrings.Add("Food seems to be scarce, and it shows from the way the clothes of the cats here hangs loose over thin bodies.");
		famineTownStatusStrings.Add("There seems to be a large number of beggars here, searching for food. It appers this passing harvest has not been kind.");
	}

	public void updatebountyCropTownStatusStrings()
	{
		bountyCropTownStatusStrings.Add("The stalls at the markets are abundant with food - It appears that this passing harvest was bountiful!");
        bountyCropTownStatusStrings.Add("You hear some farmers walking by talk excitedly about the bounty crop they've just produced!");
    }

	public void updateatWarTownStatusStrings()
	{
		atWarTownStatusStrings.Add("There are weapons being passed out on the streets - this is a city at war.");
		atWarTownStatusStrings.Add("The city walls seem extra fortified, as though they are expecting invasion at any moment. This is a city at war.");
	}

}
