using UnityEngine;
using System.Collections;

public class HealthPackEntity : ItemEntity {
	
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		itemType = new HealthPack();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward * -2f);
	}

	public override void GetItem() {
		player.GetComponent<Inventory>().Add(new HealthPack());
		//gameObject.SetActive(false);
		Destroy(gameObject);
	}
}
