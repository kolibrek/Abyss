using UnityEngine;
using System.Collections;

public class HealthPackEntity : ItemEntity {
	
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward * -2f);
	}

	public override void GetItem() {
		HealthPack itemCopy = ScriptableObject.CreateInstance<HealthPack>();
		itemCopy.sprite = itemType.sprite;
		player.GetComponent<Inventory>().Add(itemCopy);
		Destroy(gameObject);
	}
}
