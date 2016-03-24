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



	}
}

