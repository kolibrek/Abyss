using UnityEngine;
using System.Collections;

public class newScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int x = MultiplyByTwo (75);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// returns an int that is double the input.
	int MultiplyByTwo(int num) {
		return num * 2;
	}
}
