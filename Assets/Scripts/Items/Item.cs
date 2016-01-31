using UnityEngine;
using System.Collections;

public class Item {

	public string name;
	public Rarity rarity;

	public virtual bool UseItem() {
		return false;
	}
}

public enum Rarity {
	Common = 1,
	Uncommon = 2,
	Rare = 3,
	Unique = 4
}
