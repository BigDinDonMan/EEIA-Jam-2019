using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalType {
	Chicken = 15,
	Pig = 40,
	Cow = 65
}

public class Animal : MonoBehaviour
{
    public float speed;
    public AnimalType type;
}
