using System;

namespace ItemGen
{

	public class Item
	{
		public string name;
		private string baseName;
		private string prefix;
		private string suffix;

		public QualityType qualityType;
		public ItemType itemType;
		public int level;

		public int statPoints;

		public Random r = new Random ();

		public Item(string prefix, string baseName, string suffix, QualityType qualityType, ItemType itemType)
		{
			this.prefix = prefix;
			this.baseName = baseName;
			this.suffix = suffix;
			this.qualityType = qualityType;
			this.itemType = itemType;
		
			this.level = r.Next(10)+1;

			this.statPoints = StatCalculator.getStatBase(this.level,this.itemType);
			this.statPoints = this.statPoints + (int)Math.Round(this.statPoints * StatCalculator.getQualityMultiplier(qualityType));
			this.statPoints = StatCalculator.statWiggle (this.statPoints, r);

			string suffixStr = suffix != string.Empty ? "of " + suffix : "";
			this.name = string.Format ("{0} {1} {2}", prefix, baseName, suffixStr);
		}

		public override string ToString ()
		{
			switch (itemType) {
				case ItemType.FastMelee:
				case ItemType.MedMelee:
				case ItemType.SlowMelee:
					return printWeapon ();
				case ItemType.FastRanged:
				case ItemType.FastThrown:
				case ItemType.MedRanged:
				case ItemType.MedThrown:
				case ItemType.SlowRanged:
				case ItemType.SlowThrown:
					return printRanged ();
				default:
					return printItem ();
			}

		}


		private string printItem()
		{
			string retval = string.Format ("{0}\nLvl: {1} - {2}\n{3}\nAC: {4}", name,level.ToString(), qualityType.ToString(), itemType.ToString(), statPoints.ToString());
			return retval;	
		}

		private string printWeapon()
		{
			string dmgRange = StatCalculator.getWeaponDmgRange (statPoints, itemType);
			int AP = StatCalculator.getAP (itemType, qualityType, r);
			string retval = string.Format ("{0}\nLvl: {1} - {2}\n{3}\nDmg: {4} AP: {5}\n", name,level.ToString(), qualityType.ToString(), itemType.ToString(), dmgRange, AP.ToString());
			return retval;	
		}

		private string printRanged()
		{
			string dmgRange = StatCalculator.getWeaponDmgRange (statPoints, itemType);
			int AP = StatCalculator.getAP (itemType, qualityType, r);
			int range = StatCalculator.getRange (itemType, qualityType, r);
			string retval = string.Format ("{0}\nLvl: {1} - {2}\n{3}\nDmg: {4} AP: {5} Rng: {6}\n", name,level.ToString(), qualityType.ToString(), 
				itemType.ToString(), dmgRange, AP.ToString(), range.ToString());
			return retval;	
		}
	}

	public class ItemFactory
	{
		public static Item getItem(NameLibrary lib)
		{
			ItemType itemType = lib.getItemType ();
			return new Item(lib.getPrefix(),lib.getBaseNameForItemType(itemType),lib.getSuffix(),lib.getQuality(),itemType);
		}

		public static Item getItemForType(NameLibrary lib, ItemType type)
		{
			return new Item(lib.getPrefix(),lib.getBaseNameForItemType(type),lib.getSuffix(),lib.getQuality(),type);
		}
			
	}
		
}

