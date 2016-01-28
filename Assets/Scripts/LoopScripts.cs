using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoopScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//WhileLoop();
		//DoWhileLoop();
		//ForLoop();
		ForEachLoop ();
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
	/*
		int arraySize = 3;
		int[] donutBoxes = new int[arraySize];

		donutBoxes [0] = 12;
		donutBoxes [1] = 10;
		donutBoxes [2] = 13;

		foreach(int i in donutBoxes) {
			Debug.Log (i + " donuts in current box.");
		}

		int largeBox = donutBoxes[1] * 10;
	*/

		List<string> peopleMet = new List<string>();

		peopleMet.Add ("Sawyer");
		peopleMet.Add ("Kevin");

		foreach (string person in peopleMet) {
			Debug.Log(person);
		}

		peopleMet.Add ("Mike");
		peopleMet.Remove ("Kevin");

		foreach (string person in peopleMet) {
			Debug.Log(person);
		}

	}
}
