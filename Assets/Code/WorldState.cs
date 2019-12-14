using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldState : ScriptableObject
{

    public string stateName; //just a name for lookup purposes
    public int modifier; //This is the percentage by which an items price will be modified
    public string affectsBuySell; //Either 'buyPrice' or 'sellPrice', which price the modifier will affect
    public string modifierType; //This will be either 'subtraction' or 'addition'
    public bool affectsTags; //True if the state applies only to certain item tags (true of most conditions) - if false, modifier will apply to every item
    public string affectedTag; //The tags to affect!

    // Active effects

    public bool affectsTownInventory;
    public string affectToTownInventory; //either exclude or include
    public string inventoryAffectedTag; //tags of items that will either be included/excluded from inventory

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
