using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
	bool collision = false;
	float value = 30f;
    void OnTriggerEnter(Collider other) {
    	if (other.gameObject.CompareTag("Player")) {
    		if (collision) return;
    		Stats.GetInstance().ModifyFuel(value);
    		collision = true;
    		Destroy(this.gameObject);
    	}
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Beam")) {
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 20f);
        }
    }
}
