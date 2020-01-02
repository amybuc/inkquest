using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

	//Inventory
    public GameObject inventoryCanvas;
    public GameObject inventoryContent;
    public Text inventoryCoinCount;
    public Text townUICoinCount;

	//Settings
	public GameObject settingsCanvas;


    public GameObject mainCanvas;
    GameObject GameController;
    public GameObject notificationBar;
    public Text notificationText;

    public Player player;
    public GameObject itemPrefab;

	// Use this for initialization
	void Start () {

        GameController = GameObject.Find("GameController");
		
	}


	
	// Update is called once per frame
	void Update () {
		
	}

    public void openInventory()
    {
        inventoryCanvas.SetActive(true);
        refreshInventory();
        mainCanvas.SetActive(false);
        foreach (Item _item in player.inventory)
        {

            GameObject listItem = Instantiate(itemPrefab);
            listItem.transform.SetParent(inventoryContent.transform);
            Text[] textChildren = listItem.GetComponentsInChildren<Text>();
            foreach (Text _text in textChildren)
            {
                if (_text.gameObject.name == "ItemNameText")
                {
                    _text.text = _item.itemName;
                }
                if (_text.gameObject.name == "BuyPriceText")
                {
                    //Change the price of the text based on conditions active on the town HERE
                    _text.text = _item.basePrice.ToString();
                }
                if (_text.gameObject.name == "ItemQuantityText")
                {
                    _text.text = _item.quantity.ToString();
                }
            }
            Image[] imagechildren = listItem.GetComponentsInChildren<Image>();
            foreach (Image _image in imagechildren)
            {
                if (_image.gameObject.name == "ItemImage")
                {
                    _image.sprite = Resources.Load<Sprite>(_item.imageUrl);
                }
            }
        }
        inventoryCoinCount.text = player.playerCoins.ToString();
    }

    public void openMap()
    {

    }

    public void openSettings()
    {
		settingsCanvas.SetActive(true);
		mainCanvas.SetActive(false);
	}

	public void quitGame()
	{
		Application.Quit();
	}

    public void refreshTownUIPlayerCoinCoint()
    {
        townUICoinCount.text = player.playerCoins.ToString();
    }

    public void closeAndReturnToGame()
    {
        inventoryCanvas.SetActive(false);
		settingsCanvas.SetActive(false);
		//Add other canvases to be false here as theyre made
		mainCanvas.SetActive(true);
    }

    public void refreshInventory()
    {
        foreach (Transform child in inventoryContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void ShowNotification(string notifText)
    {
        notificationBar.SetActive(true);
        StartCoroutine(showNotificationEnumerator(notifText));
    }

    public IEnumerator showNotificationEnumerator(string notifText) // possibly later, add an optional parameter to set the amount of time the notif shows for
    {
        Debug.Log("Show Notification enumerator started!");
        notificationText.text = notifText;
        notificationBar.GetComponent<Animator>().SetTrigger("ShowNotif");
        yield return new WaitForSeconds(4);
        notificationBar.GetComponent<Animator>().SetTrigger("HideNotif");
        //notificationBar.SetActive(false);
        yield break;

    }
}
