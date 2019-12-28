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
     *      clothes
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
        Potato.imageUrl = "ItemImages/item_potato";
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

        Item Axe = new Item();
        Axe.itemName = "Axe";
        Axe.itemDescription = "The most versatile of tools - chop some wood, or the heads of your foes!";
        Axe.basePrice = 40;
        Axe.imageUrl = "ItemImages/item_axe";
        Axe.tag = "weapon";
        Axe.rarity = "uncommon";
        Axe.quantity = 1;
        database.Add(Axe);

        Item ForestBerries = new Item();
        ForestBerries.itemName = "Forest Berries";
        ForestBerries.itemDescription = "Sweet and tasty - just be sure it's not nightshade!";
        ForestBerries.basePrice = 10;
        ForestBerries.imageUrl = "ItemImages/item_berries";
        ForestBerries.tag = "food";
        ForestBerries.rarity = "common";
        ForestBerries.quantity = 1;
        database.Add(ForestBerries);

        Item ToughBoots = new Item();
        ToughBoots.itemName = "Tough Boots";
        ToughBoots.itemDescription = "These boots will endure any terrain, but damn are they uncomfy";
        ToughBoots.basePrice = 50;
        ToughBoots.imageUrl = "ItemImages/item_boots";
        ToughBoots.tag = "clothes";
        ToughBoots.rarity = "uncommon";
        ToughBoots.quantity = 1;
        database.Add(ToughBoots);

        Item HuntingBow = new Item();
        HuntingBow.itemName = "Hunting Bow";
        HuntingBow.itemDescription = "Silent and deadly, your enemies/prey will never see you coming!";
        HuntingBow.basePrice = 45;
        HuntingBow.imageUrl = "ItemImages/item_bow";
        HuntingBow.tag = "weapon";
        HuntingBow.rarity = "uncommon";
        HuntingBow.quantity = 1;
        database.Add(HuntingBow);

        Item Candle = new Item();
        Candle.itemName = "Candle";
        Candle.itemDescription = "Go on, touch the flame, I dare you";
        Candle.basePrice = 10;
        Candle.imageUrl = "ItemImages/item_candle";
        Candle.tag = "object";
        Candle.rarity = "common";
        Candle.quantity = 1;
        database.Add(Candle);

        Item CookedSteak = new Item();
        CookedSteak.itemName = "Cooked Steak";
        CookedSteak.itemDescription = "Seared and smoked over an open flame, done medium-well";
        CookedSteak.basePrice = 35;
        CookedSteak.imageUrl = "ItemImages/item_cookedsteak";
        CookedSteak.tag = "food";
        CookedSteak.rarity = "uncommon";
        CookedSteak.quantity = 1;
        database.Add(CookedSteak);

        Item CoastwatersCrab = new Item();
        CoastwatersCrab.itemName = "Coastwaters Crab";
        CoastwatersCrab.itemDescription = "Crab caught off the eastern coast, the meat is tender and delicious!";
        CoastwatersCrab.basePrice = 30;
        CoastwatersCrab.imageUrl = "ItemImages/item_crab";
        CoastwatersCrab.tag = "food";
        CoastwatersCrab.rarity = "common";
        CoastwatersCrab.quantity = 1;
        database.Add(CoastwatersCrab);

        Item CoastwatersFish = new Item();
        CoastwatersFish.itemName = "Coastwaters Fish";
        CoastwatersFish.itemDescription = "A coastal delicacy, or a fun low-maintenance pet!";
        CoastwatersFish.basePrice = 15;
        CoastwatersFish.imageUrl = "ItemImages/item_fish";
        CoastwatersFish.tag = "food";
        CoastwatersFish.rarity = "common";
        CoastwatersFish.quantity = 1;
        database.Add(CoastwatersFish);

        Item FishingRod = new Item();
        FishingRod.itemName = "Fishing Rod";
        FishingRod.itemDescription = "Give a man a fish, he eats for a day. Teach a man to fish, he dies of boredom";
        FishingRod.basePrice = 20;
        FishingRod.imageUrl = "ItemImages/item_fishingrod";
        FishingRod.tag = "object";
        FishingRod.rarity = "uncommon";
        FishingRod.quantity = 1;
        database.Add(FishingRod);

        Item Hammer = new Item();
        Hammer.itemName = "Hammer";
        Hammer.itemDescription = "Sure, but it's pretty useless without the nails";
        Hammer.basePrice = 25;
        Hammer.imageUrl = "ItemImages/item_hammer";
        Hammer.tag = "object";
        Hammer.rarity = "uncommon";
        Hammer.quantity = 1;
        database.Add(Hammer);

        Item WartimeFigurine = new Item();
        WartimeFigurine.itemName = "Wartime Figurine";
        WartimeFigurine.itemDescription = "It's a beautiful old statue commemorating some ancient war hero";
        WartimeFigurine.basePrice = 70;
        WartimeFigurine.imageUrl = "ItemImages/item_figurine";
        WartimeFigurine.tag = "jewellery";
        WartimeFigurine.rarity = "rare";
        WartimeFigurine.quantity = 1;
        database.Add(WartimeFigurine);

        Item InkPot = new Item();
        InkPot.itemName = "Inkpot";
        InkPot.itemDescription = "The pen is mightier than the sword! Just a shame you only have the ink, I guess";
        InkPot.basePrice = 12;
        InkPot.imageUrl = "ItemImages/item_ink";
        InkPot.tag = "object";
        InkPot.rarity = "common";
        InkPot.quantity = 1;
        database.Add(InkPot);

        Item JamJar = new Item();
        JamJar.itemName = "Berry Jam";
        JamJar.itemDescription = "Made of ripe forest berries and delicious on toast!";
        JamJar.basePrice = 15;
        JamJar.imageUrl = "ItemImages/item_jamjar";
        JamJar.tag = "food";
        JamJar.rarity = "common";
        JamJar.quantity = 1;
        database.Add(JamJar);

        Item MagicMask = new Item();
        MagicMask.itemName = "Mysterious Mask";
        MagicMask.itemDescription = "A strange mask made of wood - I wonder where it came from?";
        MagicMask.basePrice = 25;
        MagicMask.imageUrl = "ItemImages/item_mask";
        MagicMask.tag = "magic";
        MagicMask.rarity = "rare";
        MagicMask.quantity = 1;
        database.Add(MagicMask);

        Item Meat = new Item();
        Meat.itemName = "Raw Meat";
        Meat.itemDescription = "Fresh from the hunt! Ready for cooking, salting, or hey, eating raw, I don't judge";
        Meat.basePrice = 17;
        Meat.imageUrl = "ItemImages/item_meat";
        Meat.tag = "food";
        Meat.rarity = "common";
        Meat.quantity = 1;
        database.Add(Meat);

        Item CoastwatersOctopus = new Item();
        CoastwatersOctopus.itemName = "Coastwaters Octopus";
        CoastwatersOctopus.itemDescription = "A coastal rarity! Only few can say they've tried this delicious treat";
        CoastwatersOctopus.basePrice = 40;
        CoastwatersOctopus.imageUrl = "ItemImages/item_octopus";
        CoastwatersOctopus.tag = "food";
        CoastwatersOctopus.rarity = "rare";
        CoastwatersOctopus.quantity = 1;
        database.Add(CoastwatersOctopus);

        Item Pear = new Item();
        Pear.itemName = "Pear";
        Pear.itemDescription = "Tasty and sweet, this is a staple of the forest";
        Pear.basePrice = 5;
        Pear.imageUrl = "ItemImages/item_pear";
        Pear.tag = "food";
        Pear.rarity = "common";
        Pear.quantity = 1;
        database.Add(Pear);

        Item IronMace = new Item();
        IronMace.itemName = "Iron Mace";
        IronMace.itemDescription = "Spikey and solid, this weapon packs a real brutal punch";
        IronMace.basePrice = 50;
        IronMace.imageUrl = "ItemImages/item_mace";
        IronMace.tag = "weapon";
        IronMace.rarity = "uncommon";
        IronMace.quantity = 1;
        database.Add(IronMace);

        Item Poison = new Item();
        Poison.itemName = "Poison Vial";
        Poison.itemDescription = "The subtlest of weapons";
        Poison.basePrice = 60;
        Poison.imageUrl = "ItemImages/item_poison";
        Poison.tag = "weapon";
        Poison.rarity = "uncommon";
        Poison.quantity = 1;
        database.Add(Poison);

        Item PricklyPear = new Item();
        PricklyPear.itemName = "Prickly Pear";
        PricklyPear.itemDescription = "Just as sweet as a regular pear, this is spikey desert fruit puts up a fight";
        PricklyPear.basePrice = 8;
        PricklyPear.imageUrl = "ItemImages/item_pricklypear";
        PricklyPear.tag = "food";
        PricklyPear.rarity = "common";
        PricklyPear.quantity = 1;
        database.Add(PricklyPear);

        Item RawSteak = new Item();
        RawSteak.itemName = "Raw Steak";
        RawSteak.itemDescription = "Sliced and ready for cooking!";
        RawSteak.basePrice = 15;
        RawSteak.imageUrl = "ItemImages/item_rawsteak";
        RawSteak.tag = "food";
        RawSteak.rarity = "common";
        RawSteak.quantity = 1;
        database.Add(RawSteak);

        Item RubyRing = new Item();
        RubyRing.itemName = "Ruby Ring";
        RubyRing.itemDescription = "It's bright and red, it'd probably make a beautiful gift!";
        RubyRing.basePrice = 50;
        RubyRing.imageUrl = "ItemImages/item_ring";
        RubyRing.tag = "jewellery";
        RubyRing.rarity = "uncommon";
        RubyRing.quantity = 1;
        database.Add(RubyRing);

        Item Seaweed = new Item();
        Seaweed.itemName = "Seaweed";
        Seaweed.itemDescription = "Anyone for sushi?";
        Seaweed.basePrice = 5;
        Seaweed.imageUrl = "ItemImages/item_seaweed";
        Seaweed.tag = "food";
        Seaweed.rarity = "common";
        Seaweed.quantity = 1;
        database.Add(Seaweed);

        Item IronShield = new Item();
        IronShield.itemName = "Iron Shield";
        IronShield.itemDescription = "Not technically a weapon, but you won't see any pacifists with one";
        IronShield.basePrice = 55;
        IronShield.imageUrl = "ItemImages/item_shield";
        IronShield.tag = "weapon";
        IronShield.rarity = "uncommon";
        IronShield.quantity = 1;
        database.Add(IronShield);

        Item IronSword = new Item();
        IronSword.itemName = "Iron Sword";
        IronSword.itemDescription = "The quintessential warrior's weapon!";
        IronSword.basePrice = 45;
        IronSword.imageUrl = "ItemImages/item_sword";
        IronSword.tag = "weapon";
        IronSword.rarity = "common";
        IronSword.quantity = 1;
        database.Add(IronSword);

        Item Earthworm = new Item();
        Earthworm.itemName = "Earthworm";
        Earthworm.itemDescription = "C'mon man, what are you doing trying to sell worms?? Ew";
        Earthworm.basePrice = 2;
        Earthworm.imageUrl = "ItemImages/item_earthworm";
        Earthworm.tag = "object";
        Earthworm.rarity = "common";
        Earthworm.quantity = 1;
        database.Add(Earthworm);


    }


    //BOOK DATABASE
    //In the item dictionary, you can read the books you've added. Offers lore.


}
