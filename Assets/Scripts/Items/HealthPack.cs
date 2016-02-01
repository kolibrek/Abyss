using UnityEngine;
using System.Collections;

public class HealthPack : ItemStack {

	GameObject player;

	public HealthPack() {
		name = "Health Pack";
		count = 1;
		maxCount = 9;
		rarity = Rarity.Common;
	}

	void Start() {
		//name = "Health Pack";

	}

	public override bool UseItem() {
		player = GameObject.Find("Player");
		player.GetComponent<HealthController>().TakeDamage(-5);
		player.GetComponent<Inventory>().Remove(this);
		return true;
	}
}
