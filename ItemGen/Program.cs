using System;

namespace ItemGen
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			NameLibrary lib = new NameLibrary ();
			while (true) {
				Console.WriteLine ("\n(m) melee, (r) ranged, (t) thrown, (h) head, (c) chest, (l) legs, (g) gloves, (b) boots, (i) misc\n");

				ConsoleKeyInfo c = Console.ReadKey ();
				Console.WriteLine ("\n\n");

				Console.Write (ItemFactory.getItemForType (lib, getItemType(c.KeyChar)));
			}
		}

		public static ItemType getItemType(char c){
			switch(c)
			{
			case 'm':
				return ItemType.FastMelee;
			case 'r':
				return ItemType.FastRanged;
			case 't':
				return ItemType.FastThrown;
			case 'h':
				return ItemType.Head;
			case 'c':
				return ItemType.Chest;
			case 'l':
				return ItemType.Legs;
			case 'g':
				return ItemType.Gloves;
			case 'b':
				return ItemType.Boots;
			case 'i':
				return ItemType.Misc;
			default:
				return ItemType.FastMelee;
			}
		}
	}
}
