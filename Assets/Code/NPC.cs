using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    [Header("What does the NPC Say?")]
    public string[] dialogue;

    [Header("Does the NPC say something different the second time you interact?")]
    public bool hasOneTimeDialogue;
    public string[] oneTimeDialogue;

    [Header("Does the NPC give or take an item to/from the player after speaking?")]
    public bool givesAnItem;
    public bool takesAnItem;
    public string NPCItem;

    [Header("[ QUEST BEHAVIOUR ]")]
    [Header("Does the NPC have a quest?")]
    public bool hasQuest;
    public bool questComplete;

    [Header("Does the NPC want you to find an item? What is it?")]
    public bool questWantsItem;
    public string itemWanted;

    [Header("Quest-Specific Dialogue")]
    public string[] questDialogue;
    public string[] playerDoesntHaveItem;
    public string[] playerDoesntGiveItem;
    public string[] playerGivesItem;

    [HideInInspector]
    public bool hasSpoken;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
