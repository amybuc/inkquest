using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellItem : MonoBehaviour {

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

    public void sellItem()
    {
        Debug.Log("Selling item!");
        Item _item = GameController.findItemInPlayerInventory(itemID);
        if (_item.quantity > 1)
        {
            _item.quantity -= 1;
            Player.playerCoins = Player.playerCoins + itemCost;
            townUI.clearTownInventory();
            townUI.PopulatePlayerSellInventory();
            GameControllerUI.refreshTownUIPlayerCoinCoint();
        }
        else if (_item.quantity == 1)
        {
            GameController.removeItemFromInventory(itemID);
            townUI.clearTownInventory();
            townUI.PopulatePlayerSellInventory();
            Player.playerCoins = Player.playerCoins + itemCost;
            GameControllerUI.refreshTownUIPlayerCoinCoint();
        }


    }
}
