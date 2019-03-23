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
    public ShipMovement scriptRef;
    public bool collision = false;
    public bool isInBeam;
    private Quaternion basicRotation;
    private Rigidbody rb;

    void OnDestroy() {
    	if (scriptRef.beamAnimals.Contains(this)) {
    		scriptRef.beamAnimals.Remove(this);
    	}
    }

    void Start() {
    	Destroy(this.gameObject, 35f);
    	isInBeam = false;
    	if (player == null) player = GameObject.FindWithTag("Player").transform;
    	rb = GetComponent<Rigidbody>();
    	scriptRef = player.gameObject.GetComponent<ShipMovement>();
    }

    void Update() {
    	if (!isInBeam) {
    		//transform.Translate(transform.forward * speed * Time.deltaTime);
    		if (scriptRef.beamAnimals.Contains(this)) {
    			scriptRef.beamAnimals.Remove(this);
    		}
    		basicRotation = this.transform.rotation;
    		rb.useGravity = true;
    	} else {
    		//rb.useGravity = false;
    		/*this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, speed * Time.deltaTime);
    		this.transform.LookAt(player);*/
    		if (!scriptRef.beamAnimals.Contains(this)) {
    			scriptRef.beamAnimals.Add(this);
    		}
    	}
    }



    void OnTriggerStay(Collider other) {

    	if (other.gameObject.CompareTag("Beam")) isInBeam = true;	
    	else isInBeam = false;
    }

    void OnTriggerEnter(Collider other) {
    	
    	if (other.gameObject.CompareTag("Player")) {
    		if (collision) return;
    		collision = true;
    		Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
    		rb.constraints = RigidbodyConstraints.FreezePositionY;
    		Stats.GetInstance().ModifyMoney((int)this.type);
    		UIManager.instance.UpdateMoney();
    		scriptRef.transform.rotation = scriptRef.basicRotation;
    		rb.constraints = RigidbodyConstraints.None;
    		Destroy(this.gameObject);
    	}
    }

    void OnTriggerExit(Collider other) {
    	if (other.gameObject.CompareTag("Beam")) isInBeam = false;
    }

    public void BumpUpwards(float forceValue) {
    	Debug.Log("bumped: " + this.transform.name);
    	rb.AddForce(Vector3.up * forceValue, ForceMode.Force);
    }
}
