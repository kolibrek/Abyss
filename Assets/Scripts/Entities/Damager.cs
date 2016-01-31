using UnityEngine;
using System.Collections;

public class Damager : MonoBehaviour {
	
	public int damage;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * -20f);
	}

	public int GetDamageAmount() {
		return damage;
	}
}
