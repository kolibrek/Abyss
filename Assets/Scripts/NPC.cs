using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class NPC : MonoBehaviour {

	public Controller2D controller;

	// Use this for initialization
	public virtual void Start () {
		controller = GetComponent<Controller2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
