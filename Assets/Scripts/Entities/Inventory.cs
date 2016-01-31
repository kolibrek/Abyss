using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public int size;
	private List<Item> inventory;

	// Use this for initialization
	public void Start () {
		inventory = new List<Item>();
	}

	public void Add(Item item) {
		if (inventory.Count < size) {
			inventory.Add(item);
		}
	}

	public void Remove(Item item) {
		inventory.Remove(item);
	}

	public void Display() {
		if (inventory.Count != 0) {
			foreach(Item item in inventory) {
				Debug.Log(item.name);
			}
		} else {
			Debug.Log("Inventory Empty!");
		}
	}

	public void AddSlots(int slots) {
		size += slots;
	}

	public void RemoveSlots(int slots) {
		if (size - slots >= 0) {
			size -= slots;
		} else {
			size = 0;
		}
	}

	public void Sort() {
		inventory.Sort();
	}
}
