using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Town : MonoBehaviour {

    public string townName;
	public string townLocation; //can either be coastal, forest or desert
	public int relationship; //can be between 0 and 100

    public GameObject townCanvas;
	public GameObject itemView;
	public GameObject townStatusview;
    public GameObject itemScrollViewContent;
    public GameObject mainCanvas;

    public Button BuyButton;
    public Button SellButton;
	public Button TownStatusButton;

	//Conditional Events Handlers
	public List<WorldState> activeState;
    //public WorldState passiveState;

    public List<Item> shopItems;

    public int rel_player;

    //Buy/Sell Items
    GameObject ItemScrollViewport;

    //Global objects
    GameObject GameController;
    public GameObject itemPrefab;
    public GameObject sellItemPrefab;
    Player player;



    

	// Use this for initialization
	void Start () {
    
        GameController = GameObject.Find("GameController");
        player = GameObject.Find("Player").GetComponent<Player>();
		rel_player = 50; //Player - town relationship defaults to 50


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PopulateTownInventory()
    {
        //Clear the scrollview
        clearTownInventory();
        GameController.GetComponent<UIHandler>().refreshTownUIPlayerCoinCoint();

        //For now, just populate with all items in the database
        foreach (Item _item in shopItems)
        {
            GameObject listItem = Instantiate(itemPrefab);
            listItem.transform.SetParent(itemScrollViewContent.transform);
            Text[] textChildren = listItem.GetComponentsInChildren<Text>();
            int price;

            foreach (Text _text in textChildren)
            {
                if (_text.gameObject.name == "ItemNameText")
                {
                    _text.text = _item.itemName;
                }
                if (_text.gameObject.name == "BuyPriceText")
                {
                    //BUY PRICE CALCULATION

                    //Start with the base price
                    int calcPrice = _item.basePrice;

                    //Checking if the state active on the town affects item buying price
                    if (activeState[0].affectsBuySell == "buyprice")
                    {
                        //Debug.Log("1. Town's active effect affects buyprice!");
                        //Does the state only affect certain tags?
                        if (activeState[0].affectsTags)
                        {
                            //Debug.Log("2. Town's effect only affects certain item tags!");
                            //Check if the tag is equal to the states affected tag
                            if (_item.tag == activeState[0].affectedTag)
                            {
                                //Debug.Log("3. This item, " + _item.itemName + ", will be affected by the effect!");
                                //Now check the modifier!
                                if (activeState[0].modifierType == "addition")
                                {
                                    float effectmodifier = (float)activeState[0].modifier;
                                    float basePrice = (float)_item.basePrice;
                                    int modifier = returnPercentage(effectmodifier, basePrice);
									calcPrice = _item.basePrice + modifier;

                                    //Debug.Log("item " + _item.itemName + "had a base price of " + _item.basePrice + " but it's been changed to " + calcPrice);

                                }
                                if (activeState[0].modifierType == "subtraction")
                                {
                                    float effectmodifier = (float)activeState[0].modifier;
                                    float basePrice = (float)_item.basePrice;
                                    int modifier = returnPercentage(effectmodifier, basePrice);
                                    calcPrice = _item.basePrice - modifier;

                                    //Debug.Log("item " + _item.itemName + "had a base price of " + _item.basePrice + " but it's been changed to " + calcPrice);

                                }


                            }
                        }

						//NEED AN ELSE HERE - that just applies the modifier to every item
						else if (activeState[0].affectedTag == null)
						{
							//Now check the modifier!
							if (activeState[0].modifierType == "addition")
							{
                                float effectmodifier = (float)activeState[0].modifier;
                                float basePrice = (float)_item.basePrice;
                                int modifier = returnPercentage(effectmodifier, basePrice);
                                calcPrice = _item.basePrice + modifier;
                                //Debug.Log("item " + _item.itemName + "had a base price of " + _item.basePrice + " but it's been changed to " + calcPrice);
                            }
							if (activeState[0].modifierType == "subtraction")
							{
                                float effectmodifier = (float)activeState[0].modifier;
                                float basePrice = (float)_item.basePrice;
                                int modifier = returnPercentage(effectmodifier, basePrice);
                                calcPrice = _item.basePrice - modifier;
                                //Debug.Log("item " + _item.itemName + "had a base price of " + _item.basePrice + " but it's been changed to " + calcPrice);
                            }
						}
					}
       
                    _text.text = calcPrice.ToString();
                    _item.basePrice = calcPrice;
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
            listItem.GetComponentInChildren<BuyItem>().itemID = _item.itemName;
            listItem.GetComponentInChildren<BuyItem>().itemCost = _item.basePrice;
            listItem.GetComponentInChildren<BuyItem>().townUI = this;


        }
    }

    public void PopulatePlayerSellInventory()
    {
        GameController.GetComponent<UIHandler>().refreshTownUIPlayerCoinCoint();
        clearTownInventory();

        foreach (Item _item in player.inventory)
        {
            GameObject listItem = Instantiate(sellItemPrefab);
            listItem.transform.SetParent(itemScrollViewContent.transform);
            Text[] textChildren = listItem.GetComponentsInChildren<Text>();
            foreach (Text _text in textChildren)
            {
                if (_text.gameObject.name == "ItemNameText")
                {
                    _text.text = _item.itemName;
                }

                if (_text.gameObject.name == "BuyPriceText")
                {
					//Change the SELLING price of the text based on conditions active on the town HERE

					//Start with baseprice
					int calcPrice = _item.basePrice;

					//Checking if the active state onthe town affects item selling price
					if (activeState[0].affectsBuySell == "sellprice")
					{
                        //Debug.Log("1. Town's active effect affects sellprice!");

						//Does the state only affect certain tags?
						if (activeState[0].affectsTags)
						{
                            //Debug.Log("2. Town's effect only affects certain item tags!");

                            //Check if item tag is equaal to states affected tag
                            if (_item.tag == activeState[0].affectedTag)
							{
                                //Debug.Log("3. This item, " + _item.itemName + ", will be affected by the effect!");

                                //Now check the modifier!
                                if (activeState[0].modifierType == "addition")
								{
                                    float effectmodifier = (float)activeState[0].modifier;
                                    float basePrice = (float)_item.basePrice;
                                    int modifier = returnPercentage(effectmodifier, basePrice);
                                    calcPrice = _item.basePrice + modifier;
                                    //Debug.Log("item " + _item.itemName + "had a base price of " + _item.basePrice + " but it's been changed to " + calcPrice);

								}
								if (activeState[0].modifierType == "subtraction")
								{
                                    float effectmodifier = (float)activeState[0].modifier;
                                    float basePrice = (float)_item.basePrice;
                                    int modifier = returnPercentage(effectmodifier, basePrice);
                                    calcPrice = _item.basePrice - modifier;
                                    //Debug.Log("item " + _item.itemName + "had a base price of " + _item.basePrice + " but it's been changed to " + calcPrice);

                                }
						
							}
						}
						else if (activeState[0].affectedTag == null)
						{
                            //Debug.Log("2. This item, " + _item.itemName + ", will be affected by the effect!");

                            //Now check the modifier!
                            if (activeState[0].modifierType == "addition")
							{
                                float effectmodifier = (float)activeState[0].modifier;
                                float basePrice = (float)_item.basePrice;
                                int modifier = returnPercentage(effectmodifier, basePrice);
                                calcPrice = _item.basePrice + modifier;

                                //Debug.Log("item " + _item.itemName + "had a base price of " + _item.basePrice + " but it's been changed to " + calcPrice);

                            }
							if (activeState[0].modifierType == "subtraction")
							{
                                float effectmodifier = (float)activeState[0].modifier;
                                float basePrice = (float)_item.basePrice;
                                int modifier = returnPercentage(effectmodifier, basePrice);
                                calcPrice = _item.basePrice - modifier;

                                //Debug.Log("item " + _item.itemName + "had a base price of " + _item.basePrice + " but it's been changed to " + calcPrice);

                            }
						}
					}

                    _text.text = calcPrice.ToString();
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
            listItem.GetComponentInChildren<SellItem>().itemID = _item.itemName;
            listItem.GetComponentInChildren<SellItem>().itemCost = _item.basePrice;
            listItem.GetComponentInChildren<SellItem>().townUI = this;

        }
    }


    public void openTownMenu()
    {
        townCanvas.SetActive(true);
        mainCanvas.SetActive(false);
        PopulateTownInventory();
    }

    public void closeTownMenu()
    {
        foreach (Transform child in itemScrollViewContent.transform)
        {
            //Debug.Log("Child transform is " + child.name);
            Destroy(child.gameObject);
        }

        townCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void clearTownInventory()
    {
        foreach (Transform child in itemScrollViewContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

	public void removeItemFromTownInventory(string itemID)
	{
		foreach (Item item in shopItems)
		{
			if (item.itemName == itemID)
			{
				shopItems.Remove(item);
				return;
			}
			return;
		}
	}

	public void buyItem(string itemID)
	{
		//Debug.Log("The item should be being removed from the town's inventory!");
		removeItemFromTownInventory(itemID);
		clearTownInventory();
		PopulateTownInventory();
	}

	public void townStatusButton()
	{
		townStatusview.SetActive(true);
		itemView.SetActive(false);

		Transform[] transforms = townStatusview.GetComponentsInChildren<Transform>(true);
		foreach (Transform t in transforms)
		{
			if (t.gameObject.name == "StatusText")
			{
				t.gameObject.GetComponent<Text>().text = GameController.GetComponent<DialogueStringDatabase>().generateTownStatus(this);
			}
			if (t.gameObject.name == "TownName")
			{
				t.gameObject.GetComponent<Text>().text = townName;
			}
		}
	}

	public void buyButton()
	{
		townStatusview.SetActive(false);
		itemView.SetActive(true);
		PopulateTownInventory();
	}

	public void sellButton()
	{
		townStatusview.SetActive(false);
		itemView.SetActive(true);
		PopulatePlayerSellInventory();
	}

	public void displayTownRumours()
    {
        //SWAP UI - HIDE SCROLLVIEW AND SHOW TEXT
        //To be assigned to a button in in setupTownUI()
    }

    public void displayTownStatus()
    {
        //SWAP UI - HIDE SCROLLVIEW AND SHOW TEXT
        //To be assigned to a button in in setupTownUI()
    }

    public int returnPercentage(float percentage, float basenumber)
    {
        float num = (basenumber / 100) * percentage;
        //int someInt = (int)Math.Round(someFloat);
        int numrounded = (int)Mathf.Round(num);

        return numrounded;
    }

    public void setUpTownUIButtons()
    {
        Debug.Log("setUpTownUIButtons() is running");

        Transform[] transforms = townCanvas.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in transforms)
        {
            if (t.gameObject.name == "BuyButtom")
            {
                BuyButton = t.gameObject.GetComponent<Button>();
            }
            if (t.gameObject.name == "SellButtom")
            {
                SellButton = t.gameObject.GetComponent<Button>();
            }
			if(t.gameObject.name == "TownStatusButton")
			{
				TownStatusButton = t.gameObject.GetComponent<Button>();
			}
        }

        BuyButton.onClick.RemoveAllListeners();
        SellButton.onClick.RemoveAllListeners();
		TownStatusButton.onClick.RemoveAllListeners();
        BuyButton.onClick.AddListener(delegate { buyButton();});
        SellButton.onClick.AddListener(delegate { sellButton();});
		TownStatusButton.onClick.AddListener(delegate { townStatusButton(); });
	}
}
