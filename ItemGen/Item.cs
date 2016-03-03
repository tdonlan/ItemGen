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

		public Item(string prefix, string baseName, string suffix, QualityType qualityType, ItemType itemType)
		{
			this.prefix = prefix;
			this.baseName = baseName;
			this.suffix = suffix;
			this.qualityType = qualityType;
			this.itemType = itemType;

			string suffixStr = suffix != string.Empty ? "of " + suffix : "";
			this.name = string.Format ("{0} {1} {2}", prefix, baseName, suffixStr);
		}

		public override string ToString ()
		{
			string retval = string.Format ("{0}\n{1}\n{2}", name, qualityType.ToString(), itemType.ToString());
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

