using System;
using System.IO;

namespace ItemGen
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			bool fileMode = true;
			string fileName = "output.txt";

			NameLibrary lib = new NameLibrary ();
			while (true) {
				Console.WriteLine ("\n(m) melee, (r) ranged, (t) thrown, (h) head, (c) chest, (l) legs, (g) gloves, (b) boots, (i) misc\n");

				ConsoleKeyInfo c = Console.ReadKey ();
				Console.WriteLine ("\n\n");

				Item i = ItemFactory.getItemForType (lib, getItemType (c.KeyChar));
				Console.Write (i);
				if (fileMode) {
					saveItem (fileName, i);
				}
				
			}
		}

		private static void saveItem(string filename, Item i)
		{
			using (StreamWriter sw = File.AppendText(filename)) 
			{
				sw.WriteLine("\n");
				sw.WriteLine(i.ToString());

			}
		}



		private static ItemType getItemType(char c){
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
