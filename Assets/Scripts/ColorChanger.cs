using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {

	Color original;
	Renderer current;

	// Use this for initialization
	void Start () {
		current = GetComponent<Renderer> ();
		original = new Color(0.7f, 0.3f, 0.3f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			ChangeColor();
		}
		if (Input.GetKeyUp (KeyCode.C)) {
			RevertColor();
		}
	}

	// returns an int that is double the input.
	void ChangeColor() {
		current.material.color = new Color (Random.value, Random.value, Random.value, 1);
	}

	void RevertColor() {
		current.material.color = original;
	}
}
