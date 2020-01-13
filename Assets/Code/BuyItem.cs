using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour {

    public string itemID;
    public int itemCost;

    ItemDatabase GameController;
    UIHandler GameControllerUI;
    Player Player;
    public Town townUI;

	// Use this for initialization
	void Start () {

        GameController = GameObject.Find("GameController").GetComponent<ItemDatabase>();
        GameControllerUI = GameObject.Find("GameController").GetComponent<UIHandler>();
		Player = GameObject.Find("Player").GetComponent<Player>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void buyItem()

    {
		if (Player == null || GameControllerUI == null || townUI == null || GameController == null)
		{
			Debug.LogError("Component Missing :: BuyItem.cs");
			return;
		}

		if (Player.playerCoins >= itemCost)
        {
            StartCoroutine("buyAndAddItem");
			townUI.buyItem(itemID);
        }
        else if (Player.playerCoins < itemCost)
        {
            GameControllerUI.ShowNotification("Not enough coins!!");
            Debug.Log("NOT ENOUGH COINS - eventually, put in a warning UI message here");
        }
    }

    public IEnumerator buyAndAddItem()
    {

		if (Player == null || GameControllerUI == null || townUI == null || GameController == null)
		{
			Debug.LogError("Component Missing :: BuyItem.cs");
			yield break;
		}


		Debug.Log("Buying item!");
        Player.playerCoins -= itemCost;

        Debug.Log("Item we're looking up is itemID: " + itemID);

        if (Player.inventory.Contains(GameController.FindItemByName(itemID)))
        {
            Debug.Log("Item already exists in inventory!");
            foreach (Item item in Player.inventory)
            {
                if (item.itemName == itemID)
                {
                    item.quantity = item.quantity + 1;
                    yield return null;
                }
            }
        }
        else
        {
            GameController.addItemToInventory(itemID);
        }
		//This is unnecessary until i get quantities working in town inventory, but still!
		townUI.clearTownInventory();
		townUI.PopulateTownInventory();
		GameControllerUI.GetComponent<UIHandler>().refreshTownUIPlayerCoinCoint();

		//Destroy(gameObject);
		//RELOAD UI :: (to do)
	}

}
