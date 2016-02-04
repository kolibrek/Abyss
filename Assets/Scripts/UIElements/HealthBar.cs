using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public Controller2D controller;
	HealthController health;

	void Start() {
		health = controller.GetComponent<HealthController>();
	}

	void Update() {
		gameObject.transform.localScale = new Vector3((float)health.GetHealth() / (float)health.maxHealth, 1, 1);
	}
}
