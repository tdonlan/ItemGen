using System;

namespace ItemGen
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			NameLibrary lib = new NameLibrary ();
			while (true) {
				
				Console.Write (ItemFactory.getItemForType (lib, ItemType.FastMelee));
				Console.ReadKey ();
			}
		}
	}
}
