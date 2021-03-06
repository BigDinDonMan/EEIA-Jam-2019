﻿using System.Collections;
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

	public static int highscore;

	private static Stats instance = null;

	public static Stats GetInstance() {
		if (instance == null) instance = new Stats();
		return instance; 
	}

	private Stats() {
		money = 0;
		speed = 0f;
		health = maxHealth = 3;
		fuel = maxFuel = 150;
	}

	public void ModifyMoney(int value) => money += value;

	public void ModifyFuel(float val) {
		fuel += val;
		if (fuel > maxFuel) fuel = maxFuel;
		try {
			UIManager.instance.UpdateFuel();
		} catch (System.Exception) {}
		if (fuel <= 0f) {
			ShipMovement.gameOver = true;
		}
	}

	public void ReduceHealth(float val) {
		health -= val;
		if (health <= 0f) {
			PlayerPrefs.SetInt("highestCount", money);
			ResetStats();
            ShipMovement.gameOver = true;
		}
		UIManager.instance.UpdateHealth();
	}

	public void ResetStats() => instance = null;
}
