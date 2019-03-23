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
    private float changeDirectionTimer = 0f;

    void OnDestroy() {
    	if (scriptRef.beamAnimals.Contains(this)) {
    		scriptRef.beamAnimals.Remove(this);
    	}
    }

    void Start() {
    	isInBeam = false;
    	if (player == null) player = GameObject.FindWithTag("Player").transform;
    	rb = GetComponent<Rigidbody>();
    	scriptRef = player.gameObject.GetComponent<ShipMovement>();
    	changeDirectionTimer = Random.Range(3f, 6f);
    }

    void Update() {
    	if (!isInBeam) {
    		//transform.Translate(transform.forward * speed * Time.deltaTime);
    		if (scriptRef.beamAnimals.Contains(this)) {
    			scriptRef.beamAnimals.Remove(this);
    		}
    		basicRotation = this.transform.rotation;
    		rb.useGravity = true;
    		changeDirectionTimer -= Time.deltaTime;
    		if (changeDirectionTimer <= 0f) {
    			changeDirectionTimer = Random.Range(1f, 2f);
    			this.transform.Rotate(0f, 15f, 0f);
    		}
    		this.transform.Translate(transform.forward * speed * Time.deltaTime);
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
