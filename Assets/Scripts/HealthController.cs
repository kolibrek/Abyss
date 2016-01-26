﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class HealthController : MonoBehaviour {

	public int maxHealth;
	int health;
	bool isDead;

	Text healthText;
	Text gameOverText;
	Controller2D controller;
	Renderer render;

	Color invulnerable;
	Color normal;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Controller2D>();
		render = GetComponent<Renderer>();

		invulnerable = new Color(0.3f,0.3f,0.3f,1f);
		normal = new Color(0.7f, 0.3f, 0.3f, 1f);

		health = maxHealth;
		isDead = false;
		healthText = GameObject.Find("Health Text").GetComponent<Text>();
		gameOverText = GameObject.Find("GameOver Text").GetComponent<Text>();

		gameOverText.gameObject.SetActive(false);
		healthText.text = health + "/" + maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead) {
			if (render.material.color != invulnerable && controller.collisions.invulnerable) {
				render.material.color = invulnerable;
			}
			if (render.material.color != normal && !controller.collisions.invulnerable) {
				render.material.color = normal;
			}
		} else {

		}
	}

	void FixedUpdate() {
		healthText.text = health + "/" + maxHealth;
	}

	public void TakeDamage(int amount) {
		health -= amount;

		if (health <= 0) {
			Die();
		}
	}

	void Die() {
		isDead = true;
		healthText.gameObject.SetActive(false);
		gameOverText.gameObject.SetActive(true);
		gameObject.SetActive(false);

	}
}
