using System;
using System.Collections.Generic;

namespace ItemGen
{
	public class NameLibrary
	{
		public Dictionary<ItemType,List<string>> nameDictionary = new Dictionary<ItemType, List<string>>();
		public List<string> prefixList;
		public List<string> suffixList;

		public Random r;

		public NameLibrary ()
		{
			r = new Random ();
			fillWeapons();
			fillArmor ();
			fillPrefix ();
			fillSuffix ();
		}

		private void fillPrefix()
		{
			prefixList = new List<string> (){"Kroft", 
				"Sken", 
				"Alien", 
				"Toxic", 
				"Rusty", 
				"Ancient", 
				"Decrepid", 
				"Shiny", 
				"Metallic", 
				"Chromium", 
				"Mythical", 
				"Fiery", 
				"Glowing", 
				"Electric", 
				"Refurbished", 
				"Destroyed", 
				"Forged", 
				"Unearthed", 
				"Hacked",""  };
		}

		private void fillSuffix()
		{
			suffixList = new List<string> (){"Wrath", 
				"Hatred", 
				"Greed", 
				"Gluttony", 
				"Fire", 
				"Ice", 
				"Earth",
				"Water", 
				"Wind", 
				"Air", 
				"Poison", 
				"Rage", 
				"Vampirism", 
				"Brutality", 
				"Madness", 
				"Toughness", 
				"Lethargy", 
				"Focus", 
				"Agility", 
				"Spirit", 
				"Erudition", 
				"Knowledge", 
				"Blood", 
				"Violence", 
				"Destruction", 
				"Speed", 
				"Swiftness", 
				"Healing", 
				"Regeneration", ""};
		}

		private void fillWeapons()
		{
			List<string> wepList = new List<string> (){ "shiv",
				"dagger",
				"knife",
				"spike",
				"blade",
				"kukri",
				"sword",
				"hatchet",
				"axe",
				"pick",
				"poker",
				"spear",
				"glaive",
				"knuckles",
				"club",
				"beater",
				"stick",
				"prod",
				"claymore",
				"hammer",
				"longsword",
				"greatsword",
				"waraxe"};

			nameDictionary.Add(ItemType.FastMelee, wepList);
			nameDictionary.Add(ItemType.MedMelee, wepList);
			nameDictionary.Add(ItemType.SlowMelee, wepList);

			List<string> thrownList = new List<string> () {
				"shuriken", 
				"throwing knife", 
				"buzzers", 
				"caltrops", 
				"dart",
			};

			nameDictionary.Add(ItemType.FastThrown, thrownList);
			nameDictionary.Add(ItemType.MedThrown, thrownList);
			nameDictionary.Add(ItemType.SlowThrown, thrownList);

			List<string> rangedList = new List<string> (){"bowcaster", 
				"crossbow", 
				"bow", 
				"longbow", 
				"repeater", 
				"launcher", 
				"flinger", 
				"sling", 
				"sling-staff", 
				"atl-latl", 
				"pistol", 
				"gun", 
				"blaster", 
				"musket", 
				"carbine", 
				"blunderbuss", 
				"cannon", 
				"rifle",  };

			nameDictionary.Add(ItemType.FastRanged, rangedList);
			nameDictionary.Add(ItemType.MedRanged, rangedList);
			nameDictionary.Add(ItemType.SlowRanged, rangedList);
		}

		private void fillArmor()
		{
			List<string> itemList = new List<string> (){ "cap", 
				"helm", 
				"helmet", 
				"mask", 
				"goggles"
				};
			nameDictionary.Add(ItemType.Head, itemList);

			itemList = new List<string>(){"shirt", 
				"jacket", 
				"suit", 
				"bolster", 
				"armor", 
				"skinsuit", 
				"parka", 
				"shell"};
			nameDictionary.Add(ItemType.Chest, itemList);

			itemList = new List<string>(){"leggings", 
				"slacks", 
				"pants"};
			nameDictionary.Add(ItemType.Legs, itemList);

			itemList = new List<string>(){"gaitors", 
				"greives", 
				"boots", 
				"shoes", 
				"stompers"};
			nameDictionary.Add(ItemType.Boots, itemList);

			itemList = new List<string>(){"gloves", 
				"gauntlets", 
				"gaunts"};
			nameDictionary.Add(ItemType.Gloves, itemList);

			itemList = new List<string>(){"bauble", 
				"watch", 
				"trinket", 
				"wrench", 
				"ring", 
				"locket", 
				"spyglass", 
				"compass", 
				"chronometer", 
				"thermometer", 
				"scope", 
				"amulet", 
				"kit", 
				"bracelet", 
				"wristband", 
				"doll"};
			nameDictionary.Add(ItemType.Misc, itemList);

		}

		public T RandomEnumValue<T> ()
		{
			var v = Enum.GetValues (typeof (T));
			return (T) v.GetValue (r.Next(v.Length));
		}

		public QualityType getQuality()
		{
			return RandomEnumValue<QualityType> ();
		}
			
		public ItemType getItemType()
		{
			return RandomEnumValue<ItemType> ();
		}

		public string getBaseNameForItemType(ItemType type)
		{
			var itemList = nameDictionary [type];
			return itemList [r.Next (itemList.Count)];
		}

		public string getPrefix()
		{
			return prefixList [r.Next (prefixList.Count)];
		}

		public string getSuffix()
		{
			return suffixList [r.Next (suffixList.Count)];
		}
			
	}
}

