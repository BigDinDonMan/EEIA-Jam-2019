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
    public static Transform player;

    public bool isInBeam;

    void Start() {
    	isInBeam = false;
    	if (player == null) player = GameObject.FindWithTag("Player").transform;
    }

    void Update() {
    	if (!isInBeam) {
    		//transform.Translate(transform.forward * speed * Time.deltaTime);
    	} else {
    		this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    	}
    }



    void OnTriggerEnter(Collider other) {
    	if (other.gameObject.CompareTag("Player")) {
    		Stats.GetInstance().ModifyMoney((int)this.type);
    		UIManager.instance.UpdateMoney();
    		Destroy(this.gameObject);
    	}
    	if (other.gameObject.CompareTag("Beam")) isInBeam = true;	
    	else isInBeam = false;
    }
}
