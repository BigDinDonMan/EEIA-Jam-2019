using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
	public int money;
	public float speed;

	private static Stats instance = null;

	public static Stats GetInstance() {
		if (instance == null) instance = new Stats();
		return instance; 
	}

	private Stats() {
	}
}
