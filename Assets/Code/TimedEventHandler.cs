using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TimedEventHandler : MonoBehaviour {

    public GameObject player;
    public DateTime conditionChangeTime;

    public string[] events = {
        "Pacifist",
        "Famine",
        "MagicBan",
        "BountyCrop",
        "At War",
        "None"
    };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (System.DateTime.Now == conditionChangeTime)
        {
            //CHANGE CONDITION?
        }

        //Every 5 - 15 minutes, a town's active condition changes
		



	}



    //Events should probably be enacted twice - once when the town inventory is populated, and once when the player enters the town shop, to analyse the players inventory for multipliers


}
