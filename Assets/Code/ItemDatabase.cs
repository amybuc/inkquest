using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    /*
     * Types of Item (tags)
     *      potion
     *      food
     *      weapon
     *      health
     *      material
     *      gem/jewellery
     *      magic
     * 
     *  Levels of Rarity
     *      common
     *      uncommon
     *      rare
     *      mythical
     */

    public List<Item> database;
    public Player player;

    public Item FindItemByName(string name)
    {
        foreach (Item _item in database)
        {
            if (_item.itemName == name)
            {
                return _item;
            }
            else
            {
                //Debug.Log("Item by that name was not found in database!");
                //return null;
            }
        }
        return null;
    }

    public void addItemToInventory(string itemid)
    {
        foreach (Item _item in database)
        {
            if (_item.itemName == itemid)
            {
                player.inventory.Add(_item);
                return;
            }
        }
    }

    public void removeItemFromInventory(string itemid)
    {
        foreach (Item _item in player.inventory)
        {
            if (_item.itemName == itemid)
            {
                player.inventory.Remove(_item);
                return;
            }

        }

    }

    public List<Item> GetAllItemsOfRarity(string rarity)
    {
        List<Item> itemlist = new List<Item>();

        foreach (Item _item in database)
        {
            if (_item.rarity == rarity)
            {
                itemlist.Add(_item);
            }
        }

        return itemlist;
    }

    public Item findItemInPlayerInventory(string itemid)
    {
        foreach (Item _item in player.inventory)
        {
            if (_item.itemName == itemid)
            {
                return _item;
            }

        }
        return null;
    }

    public bool checkForItemInPlayerInventory(string itemid)
    {
        foreach(Item _item in player.inventory)
        {
            if (_item.itemName == itemid)
            {
                Debug.Log("checkForItemInPlayerInventory - player has item!");
                return true;
            }
        }
        Debug.Log("checkForItemInPlayerInventory - player does not have item!");
        return false;
    }

    public Item findRandomItem()
    {
        int randomNumber = Random.Range(0, database.Count);
        return database[randomNumber];
    }

    // Use this for initialization
    void Start ()
    {
        BuildDatabase();
		//Debug.Log("The amount of common items in the game is " + GetAllItemsOfRarity("common").Count);
		addItemToInventory("Weapon Proxy");

    }



	
	// Update is called once per frame
	void Update () {
		
	}

    public void BuildDatabase()
    {
        Debug.Log("L O G :: BuildItemDatabase Run");

        Item COMMONPROXY = new Item();
        COMMONPROXY.itemName = "Common Proxy";
        COMMONPROXY.itemDescription = "A common item";
        COMMONPROXY.basePrice = 10;
        COMMONPROXY.imageUrl = "ItemImages/item_healthpotion";
        COMMONPROXY.tag = "none";
        COMMONPROXY.rarity = "common";
        COMMONPROXY.quantity = 1;
        database.Add(COMMONPROXY);

		Item WEAPONPROXY = new Item();
		WEAPONPROXY.itemName = "Weapon Proxy";
		WEAPONPROXY.itemDescription = "A weapon";
		WEAPONPROXY.basePrice = 50;
		WEAPONPROXY.imageUrl = "ItemImages/item_healthpotion";
		WEAPONPROXY.tag = "weapon";
		WEAPONPROXY.rarity = "common";
		WEAPONPROXY.quantity = 1;
		database.Add(WEAPONPROXY);

		Item UNCOMMONPROXY = new Item();
        UNCOMMONPROXY.itemName = "Uncommon Proxy";
        UNCOMMONPROXY.itemDescription = "An Uncommon item";
        UNCOMMONPROXY.basePrice = 10;
        UNCOMMONPROXY.imageUrl = "ItemImages/item_healthpotion";
        UNCOMMONPROXY.tag = "none";
        UNCOMMONPROXY.rarity = "uncommon";
        UNCOMMONPROXY.quantity = 1;
        database.Add(UNCOMMONPROXY);

        Item RAREPROXY = new Item();
        RAREPROXY.itemName = "Rare Proxy";
        RAREPROXY.itemDescription = "A rare item";
        RAREPROXY.basePrice = 10;
        RAREPROXY.imageUrl = "ItemImages/item_healthpotion";
        RAREPROXY.tag = "none";
        RAREPROXY.rarity = "rare";
        RAREPROXY.quantity = 1;
        database.Add(RAREPROXY);

        Item MYTHICALPROXY = new Item();
        MYTHICALPROXY.itemName = "Mythical Proxy";
        MYTHICALPROXY.itemDescription = "A mythical item";
        MYTHICALPROXY.basePrice = 10;
        MYTHICALPROXY.imageUrl = "ItemImages/item_healthpotion";
        MYTHICALPROXY.tag = "none";
        MYTHICALPROXY.rarity = "mythical";
        MYTHICALPROXY.quantity = 1;
        database.Add(MYTHICALPROXY);

        Item HealthPotion = new Item();
        HealthPotion.itemName = "Health Potion";
        HealthPotion.itemDescription = "It's actually just Kombucha";
        HealthPotion.basePrice = 10;
        HealthPotion.imageUrl = "ItemImages/item_healthpotion";
        HealthPotion.tag = "potion";
        HealthPotion.rarity = "common";
        HealthPotion.quantity = 1;
        database.Add(HealthPotion);

        Item EarthyMushrooms = new Item();
        EarthyMushrooms.itemName = "Earthy Mushrooms";
        EarthyMushrooms.itemDescription = "I hope they've been washed";
        EarthyMushrooms.basePrice = 8;
        EarthyMushrooms.imageUrl = "ItemImages/item_earthymushrooms";
        EarthyMushrooms.tag = "food";
        EarthyMushrooms.rarity = "common";
        EarthyMushrooms.quantity = 1;
        database.Add(EarthyMushrooms);

        Item GlassJar = new Item();
        GlassJar.itemName = "Jar of Clouds";
        GlassJar.itemDescription = "How do they get the clouds in the jar?";
        GlassJar.basePrice = 5;
        GlassJar.imageUrl = "ItemImages/item_jarofclouds";
        GlassJar.tag = "material";
        GlassJar.rarity = "uncommon";
        GlassJar.quantity = 1;
        database.Add(GlassJar);

        Item Potato = new Item();
        Potato.itemName = "Potato";
        Potato.itemDescription = "Boil em, mash em, stick em in a stew";
        Potato.basePrice = 6;
        Potato.imageUrl = "ItemImages/item_healthpotion";
        Potato.tag = "food";
        Potato.rarity = "common";
        Potato.quantity = 1;
        database.Add(Potato);

        Item Milk = new Item();
        Milk.itemName = "Milk";
        Milk.itemDescription = "Came from a cow, probably";
        Milk.basePrice = 5;
        Milk.imageUrl = "ItemImages/item_jar";
        Milk.tag = "food";
        Milk.rarity = "common";
        Milk.quantity = 1;
        database.Add(Milk);

        Item Bread = new Item();
        Bread.itemName = "Bread Loaf";
        Bread.itemDescription = "Fluffy and soft";
        Bread.basePrice = 9;
        Bread.imageUrl = "ItemImages/item_bread";
        Bread.tag = "food";
        Bread.rarity = "common";
        Bread.quantity = 1;
        database.Add(Bread);

        Item CharmOfLuck = new Item();
        CharmOfLuck.itemName = "Charm of Luck";
        CharmOfLuck.itemDescription = "Feeling lucky?";
        CharmOfLuck.basePrice = 15;
        CharmOfLuck.imageUrl = "ItemImages/item_pendant";
        CharmOfLuck.tag = "food";
        CharmOfLuck.rarity = "rare";
        CharmOfLuck.quantity = 1;
        database.Add(CharmOfLuck);

        Item Apple = new Item();
        Apple.itemName = "Apple";
        Apple.itemDescription = "Something about keeping the doctor away?";
        Apple.basePrice = 10;
        Apple.imageUrl = "ItemImages/item_apple";
        Apple.tag = "food";
        Apple.rarity = "common";
        Apple.quantity = 1;
        database.Add(Apple);

        Item HistoryBook = new Item();
        HistoryBook.itemName = "History Book";
        HistoryBook.itemDescription = "Don't neglect your education!";
        HistoryBook.basePrice = 50;
        HistoryBook.imageUrl = "ItemImages/item_book";
        HistoryBook.tag = "book";
        HistoryBook.rarity = "uncommon";
        HistoryBook.quantity = 1;
        database.Add(HistoryBook);

        Item Wine = new Item();
        Wine.itemName = "Wine";
        Wine.itemDescription = "Saving it for a special occasion?";
        Wine.basePrice = 30;
        Wine.imageUrl = "ItemImages/item_bottle";
        Wine.tag = "food";
        Wine.rarity = "uncommon";
        Wine.quantity = 1;
        database.Add(Wine);

        Item Carrots = new Item();
        Carrots.itemName = "Carrots";
        Carrots.itemDescription = "Good for winning favour with bunnies.";
        Carrots.basePrice = 15;
        Carrots.imageUrl = "ItemImages/item_carrot";
        Carrots.tag = "food";
        Carrots.rarity = "common";
        Carrots.quantity = 1;
        database.Add(Carrots);

        Item Cloth = new Item();
        Cloth.itemName = "Cloth";
        Cloth.itemDescription = "Handy if you know how to sew!";
        Cloth.basePrice = 20;
        Cloth.imageUrl = "ItemImages/item_clothmaterial";
        Cloth.tag = "rawmaterial";
        Cloth.rarity = "uncommon";
        Cloth.quantity = 1;
        database.Add(Cloth);

        Item Wheat = new Item();
        Wheat.itemName = "Wheat";
        Wheat.itemDescription = "It wants to be bread when it grows up!";
        Wheat.basePrice = 25;
        Wheat.imageUrl = "ItemImages/item_crop";
        Wheat.tag = "food";
        Wheat.rarity = "common";
        Wheat.quantity = 1;
        database.Add(Wheat);

        Item Egg = new Item();
        Egg.itemName = "Egg";
        Egg.itemDescription = "But what came first, the chicken or.. never mind";
        Egg.basePrice = 15;
        Egg.imageUrl = "ItemImages/item_egg";
        Egg.tag = "food";
        Egg.rarity = "uncommon";
        Egg.quantity = 1;
        database.Add(Egg);

        Item Feather = new Item();
        Feather.itemName = "Feather";
        Feather.itemDescription = "It must have come from a beautiful bird";
        Feather.basePrice = 40;
        Feather.imageUrl = "ItemImages/item_feather";
        Feather.tag = "object";
        Feather.rarity = "rare";
        Feather.quantity = 1;
        database.Add(Feather);

        Item Rope = new Item();
        Rope.itemName = "Rope";
        Rope.itemDescription = "The original multipurpose wonder-tool!";
        Rope.basePrice = 30;
        Rope.imageUrl = "ItemImages/item_rope";
        Rope.tag = "rawmaterial";
        Rope.rarity = "uncommon";
        Rope.quantity = 1;
        database.Add(Rope);

        Item Stone = new Item();
        Stone.itemName = "Stone";
        Stone.itemDescription = "You can build a pretty good wall with it!";
        Stone.basePrice = 35;
        Stone.imageUrl = "ItemImages/item_stonematerial";
        Stone.tag = "rawmaterial";
        Stone.rarity = "uncommon";
        Stone.quantity = 1;
        database.Add(Stone);

        Item Wood = new Item();
        Wood.itemName = "Wood";
        Wood.itemDescription = "Those poor, poor trees";
        Wood.basePrice = 35;
        Wood.imageUrl = "ItemImages/item_woodmaterial";
        Wood.tag = "rawmaterial";
        Wood.rarity = "uncommon";
        Wood.quantity = 1;
        database.Add(Wood);



    }


    //BOOK DATABASE
    //In the item dictionary, you can read the books you've added. Offers lore.


}
