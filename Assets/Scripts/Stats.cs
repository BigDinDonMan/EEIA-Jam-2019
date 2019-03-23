using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
	public int money;
	public float speed;
	public float health;
	public float fuel;
	public float maxFuel;
	public float maxHealth;

	private static Stats instance = null;

	public static Stats GetInstance() {
		if (instance == null) instance = new Stats();
		return instance; 
	}

	private Stats() {
		money = 0;
		speed = 0f;
		health = maxHealth = 150;
		fuel = maxFuel = 150;
	}

	public void ModifyMoney(int value) => money += value;

	public void ModifyFuel(float val) => fuel += val;

	public void ReduceHealth(float val) {
		health -= val;
		if (health <= 0f) {
			ResetStats();
			UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
		}
	}

	private void ResetStats() => instance = null;
}
