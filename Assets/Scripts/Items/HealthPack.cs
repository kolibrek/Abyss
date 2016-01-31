using UnityEngine;
using System.Collections;

public class HealthPack : ItemStack {

	public HealthPack() {
		this.name = "Health Pack";
		this.count = 1;
		maxCount = 9;
		rarity = Rarity.Common;
	}

	public override bool UseItem() {
		return false;
	}
}
