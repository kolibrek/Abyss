using UnityEngine;
using System.Collections;

public abstract class ItemEntity : MonoBehaviour {

	public Item itemType;

	public abstract void GetItem();

}
