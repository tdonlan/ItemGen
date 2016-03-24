using System;

namespace ItemGen
{
	public class StatCalculator
	{
		public StatCalculator ()
		{
			

		}

		public static int getStatBase(int level, ItemType Type)
		{
			switch (Type) {
			case ItemType.FastMelee:
				return level * 3;
			case ItemType.MedMelee:
				return level * 6;
			case ItemType.SlowMelee:
				return level * 12;
			case ItemType.FastThrown:
				return level * 3;
			case ItemType.MedThrown:
				return level * 6;
			case ItemType.SlowThrown:
				return level * 12;
			case ItemType.FastRanged:
				return level * 3;
			case ItemType.MedRanged:
				return level * 6;
			case ItemType.SlowRanged:
				return level * 12;
			case ItemType.Head:
				return (int)Math.Round( (level * 15) / 4f);
			case ItemType.Chest:
				return (int)Math.Round((level * 15) / 3f);
			case ItemType.Legs:
				return (int)Math.Round((level * 15) / 4f);
			case ItemType.Boots:
				return (int)Math.Round((level * 15) / 8f);
			case ItemType.Gloves:
				return (int)Math.Round((level * 15) / 8f);
			case ItemType.Misc:
				return (int)Math.Round((level * 15) / 10f);
			default:
				return level;

			}
		}

		public static float getQualityMultiplier(QualityType type)
		{
			switch(type)
			{
			case QualityType.Poor:
				return .55f;
			case QualityType.Common:
				return .75f;
			case QualityType.Good:
				return 1;
			case QualityType.Fine:
				return 1.25f;
			case QualityType.Epic:
				return 1.5f;
			case QualityType.Legendary:
				return 2f;
			default:
				return 1;
			}
		}

		//Add some randomness to stats
		public static int statWiggle(int stat, Random r)
		{

			float range = 1 + ((float)r.NextDouble () * .1f - 0.05f);
			return (int)Math.Round (stat * range);
		}

		public static string getWeaponDmgRange(int dmg, ItemType type)
		{
			float rangeVal;
			switch(type)
			{
			case  ItemType.FastMelee:
			case ItemType.FastRanged:
			case ItemType.FastThrown:
				rangeVal = .1f;
				break;
			case ItemType.MedMelee:
			case ItemType.MedRanged:
			case ItemType.MedThrown:
				rangeVal = .2f;
				break;
			case ItemType.SlowMelee:
			case ItemType.SlowRanged:
			case ItemType.SlowThrown:
				rangeVal = .3f;
				break;
			default:
				rangeVal = .1f;
				break;
				
				
			}

			int low = dmg - (int)Math.Round (dmg * rangeVal);
			int high = dmg + (int)Math.Round (dmg * rangeVal);


			return string.Format ("{0}-{1}", low, high);
		}

		public static int getAP(ItemType type, QualityType quality, Random r)
		{

			int ap;
			switch (type) {
			case  ItemType.FastMelee:
			case ItemType.FastRanged:
			case ItemType.FastThrown:
				ap = r.Next(1,4);
				break;
			case ItemType.MedMelee:
			case ItemType.MedRanged:
			case ItemType.MedThrown:
				ap = r.Next(4,7);
				break;
			case ItemType.SlowMelee:
			case ItemType.SlowRanged:
			case ItemType.SlowThrown:
				ap = r.Next(7,10);
				break;
			default:
				ap = 5;
				break;


			}

			switch (quality) {
			case QualityType.Poor:
				ap = iClamp (ap + 1, 1, 10);
				break;

			case QualityType.Epic:
				ap = iClamp (ap - 1, 1, 10);
				break;
			case QualityType.Legendary:
				ap = iClamp (ap - 2, 1, 10);
				break;
				default:
					break;
				

			}

			return ap;
		}

		private static int iClamp(int val, int min, int max)
		{
			if (val < min) {val = min;
			}
				
			if (val > max) {val = max;
			}
			return val;
		}

		public static int getRange(ItemType type, QualityType quality, Random r)
		{

			int range;
			switch (type) {

			case ItemType.FastRanged:
			case ItemType.FastThrown:
				range = r.Next(5,10);
				break;

			case ItemType.MedRanged:
			case ItemType.MedThrown:
				range = r.Next(7,15);
				break;

			case ItemType.SlowRanged:
			case ItemType.SlowThrown:
				range = r.Next(10,20);
				break;
			default:
				range = 10;
				break;

			}

			switch (quality) {
			case QualityType.Poor:
				range = iClamp (range - r.Next(10), 5, 50);
				break;

			case QualityType.Fine:
				range = iClamp (range + r.Next(5), 5, 50);
				break;
			case QualityType.Epic:
				range = iClamp (range + r.Next(5,10), 5, 50);
				break;
			case QualityType.Legendary:
				range = iClamp (range + r.Next(10,20), 5, 50);
				break;
			default:
				break;
			}

			return range;

		}



	}
}

