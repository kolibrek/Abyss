using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Item))]
public abstract class ItemEntity : MonoBehaviour {

	public Item itemType;

	public abstract void GetItem();

}
