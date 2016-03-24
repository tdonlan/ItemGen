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
			Random r = new Random();
			int v = r.Next (3);
			switch(c)
			{
			case 'm':
				if (v == 0) {
					return ItemType.FastMelee;
				}
				else if (v == 1) {
					return ItemType.MedMelee;
				}
				else {
					return ItemType.SlowMelee;
				}
			case 'r':
				if (v == 0) {
					return ItemType.FastRanged;
				}
				else if (v == 1) {
					return ItemType.MedRanged;
				}
				else {
					return ItemType.SlowRanged;
				}
			case 't':
				if (v == 0) {
					return ItemType.FastThrown;
				}
				else if (v == 1) {
					return ItemType.MedThrown;
				}
				else {
					return ItemType.SlowThrown;
				}
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
