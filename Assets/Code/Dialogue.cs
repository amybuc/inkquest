using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Player player;
    public ItemDatabase itemDatabase;

    public GameObject dialogueBox;
    public GameObject mainCanvas;
    public GameObject queryButtons;
    public Button affButton;
    public Button negButton;
    public Button nextButton;

    public Text text;
    public bool speaking;
    public int index;
    public float typingSpeed;
    float speedstore;
    public GameCamera cam;

    public bool isQuest;
    public bool isQuestDialogueFin;

    string[] scriptStore;
    GameObject npcStore;



    // Use this for initialization
    void Start()
    {
        speedstore = typingSpeed;
        player = GameObject.Find("Player").GetComponent<Player>();
        itemDatabase = gameObject.GetComponent<ItemDatabase>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Speak(GameObject NPC)
    {
        player.isBusy = true;
        mainCanvas.SetActive(false);
        npcStore = NPC;
        cam.GetComponent<GameCamera>().isDialogue = true;

        //Some quest checks will have to go here

        if (npcStore.GetComponent<NPC>().hasQuest == true)
        {
            if (npcStore.GetComponent<NPC>().questComplete == false)
            {
                scriptStore = npcStore.GetComponent<NPC>().questDialogue;
                dialogueBox.SetActive(true);
                isQuest = true;
                text.text = "";
                StartCoroutine("Type");
                return;
            }

        }

        if (npcStore.GetComponent<NPC>().hasOneTimeDialogue == true)
        {
            if (npcStore.GetComponent<NPC>().hasSpoken == false)
            {
                scriptStore = npcStore.GetComponent<NPC>().oneTimeDialogue;
                dialogueBox.SetActive(true);
                text.text = "";
                StartCoroutine("Type");
            }
            else if (npcStore.GetComponent<NPC>().hasSpoken == true)
            {
                scriptStore = npcStore.GetComponent<NPC>().dialogue;
                dialogueBox.SetActive(true);
                text.text = "";
                StartCoroutine("Type");
            }
        }
        else
        {
            scriptStore = npcStore.GetComponent<NPC>().dialogue;
            dialogueBox.SetActive(true);
            text.text = "";
            StartCoroutine("Type");
        }


    }

    public IEnumerator Type()
    {

        foreach (char letter in scriptStore[index].ToCharArray())
        {
            text.text += letter;
            //yield return new WaitForSeconds(typingSpeed);
            yield return null;
        }
    }

    public void NextButton()
    {

        if (text.text == scriptStore[index])
        {

            if (index < scriptStore.Length - 1)
            {
                index++;
                text.text = "";
                StartCoroutine(Type());
            }
            else
            {
                //Dialogue is finished! Let's check if any inventory interaction is taking place
                player.isBusy = false;

                if (isQuest == true)
                {
                    queryForQuestItem(npcStore.GetComponent<NPC>());
                    return;
                }
                if (isQuestDialogueFin == true)
                {
                    npcStore.GetComponent<NPC>().hasSpoken = true;
                    dialogueBox.SetActive(false);
                    mainCanvas.SetActive(true);
                    index = 0;
                    cam.GetComponent<GameCamera>().isDialogue = false;
                    isQuestDialogueFin = false;
                    return;
                }

                if (npcStore.GetComponent<NPC>().givesAnItem == true && npcStore.GetComponent<NPC>().hasSpoken == false)
                {
                    Debug.Log("NPC gives the player an item");
                    npcStore.GetComponent<NPC>().hasSpoken = true;
                    this.gameObject.GetComponent<ItemDatabase>().addItemToInventory(npcStore.GetComponent<NPC>().NPCItem);
                    this.gameObject.GetComponent<UIHandler>().ShowNotification("You've been given an item!");
                    dialogueBox.SetActive(false);
                    mainCanvas.SetActive(true);
                    cam.GetComponent<GameCamera>().isDialogue = false;
                    index = 0;
                }
                else if (npcStore.GetComponent<NPC>().takesAnItem == true && npcStore.GetComponent<NPC>().hasSpoken == false)
                {
                    Debug.Log("NPC takes an item from the player");
                    npcStore.GetComponent<NPC>().hasSpoken = true;
                    this.gameObject.GetComponent<ItemDatabase>().removeItemFromInventory(npcStore.GetComponent<NPC>().NPCItem);
                    this.gameObject.GetComponent<UIHandler>().ShowNotification("An item has been removed from your inventory");
                    dialogueBox.SetActive(false);
                    mainCanvas.SetActive(true);
                    cam.GetComponent<GameCamera>().isDialogue = false;
                    index = 0;
                }
                else 
                {
                   
                    npcStore.GetComponent<NPC>().hasSpoken = true;
                    dialogueBox.SetActive(false);
                    mainCanvas.SetActive(true);
                    index = 0;
                    cam.GetComponent<GameCamera>().isDialogue = false;


                    //Check if we're in the tutorial
                    if (this.gameObject.GetComponent<TutorialHandler>().isPlayingTutorial == true)
                    {
                        this.gameObject.GetComponent<TutorialHandler>().StartCoroutine("endTutorial");
                    }

                }
            }
        }
        else
        {
            StopCoroutine("Type");
            text.text = "";
            text.text = scriptStore[index];
            StopAllCoroutines();
        }

       
    }

    public void queryForQuestItem(NPC NPC) // if player has required item, show dialogue - if not, show relevant dialogue
    {
        Debug.Log("query for quest item");

        if (itemDatabase.checkForItemInPlayerInventory(NPC.itemWanted) == true)
        {
            string[] queryString = new string[]{ "Give " + NPC.itemWanted + "?"};
            scriptStore = queryString;
            dialogueBox.SetActive(true);
            index = 0;
            text.text = "";
            StartCoroutine("Type");
            queryButtons.SetActive(true);
            nextButton.gameObject.SetActive(false);

            //Assign button functions
            affButton.onClick.RemoveAllListeners();
            negButton.onClick.RemoveAllListeners();
            affButton.onClick.AddListener(delegate { quest_giveItem(npcStore.GetComponent<NPC>()); });
            negButton.onClick.AddListener(delegate { quest_dontGiveItem(npcStore.GetComponent<NPC>()); });

        }
        else
        {
            scriptStore = NPC.playerDoesntHaveItem;
            isQuestDialogueFin = true;
            isQuest = false;
            dialogueBox.SetActive(true);
            index = 0;
            text.text = "";
            StartCoroutine("Type");
        }
    }

    public void quest_dontGiveItem(NPC npc)
    {
        StopAllCoroutines();
        scriptStore = npc.playerDoesntGiveItem;
        dialogueBox.SetActive(true);
        index = 0;
        text.text = "";
        StartCoroutine("Type");
        nextButton.gameObject.SetActive(true);
        queryButtons.SetActive(false);
        isQuestDialogueFin = true;
        isQuest = false;
 

    }

    public void quest_giveItem(NPC npc)
    {
        StopAllCoroutines();
        scriptStore = npc.playerGivesItem;
        dialogueBox.SetActive(true);
        index = 0;
        text.text = "";
        StartCoroutine("Type");
        nextButton.gameObject.SetActive(true);
        queryButtons.SetActive(false);
        itemDatabase.removeItemFromInventory(npc.itemWanted);
        this.gameObject.GetComponent<UIHandler>().ShowNotification(npc.itemWanted + " has been removed from your inventory!");
        npc.questComplete = true;
        isQuest = false;
        isQuestDialogueFin = true;

    }



}
