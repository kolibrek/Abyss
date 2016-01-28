using UnityEngine;
using System.Collections;

public class LoopScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {

		WhileLoop();
		DoWhileLoop();
		ForLoop();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void WhileLoop() {
		int donutsLeft = 13;
		while (donutsLeft > 0) {
			if (donutsLeft > 1) {
				Debug.Log("There are " + donutsLeft + " donuts in the box");
			} else {
				Debug.Log("There is " + donutsLeft + " donut in the box");
			}
		}
	}

	void DoWhileLoop() {

		bool shouldContinue = false;
		
		do {
			Debug.Log("Need more donuts!");
			
		} while(shouldContinue);
	}

	void ForLoop() {
		for (int i = 0; i < 10; i++) {
			Debug.Log ("This loop has run " + (i + 1) + " times!");
		}
	}

	void ForEachLoop() {

	}
}
