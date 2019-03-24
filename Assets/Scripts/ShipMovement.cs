using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ShipMode {
	Horizontal, Vertical
}

[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour
{
	public Gyroscope gyro = null;
	public Rigidbody rb = null;
	public Rigidbody ufoRb = null;

	public float speed;

	public float tilt;
	public float clampValue;
	public float delta;

	public ShipMode movementMode;

	public Quaternion basicRotation;
	public Quaternion basicCameraRotation;

	public Camera cam;

	public Vector3 offset;

	public float rotateAngle;
	public float beamForce;

	public Transform beamPoint;

	public Transform movingParticles;
	public Transform beamParticles;

	public static bool buttonPressed = false;

	public static bool gameOver = false;
	public bool savedHighScore = false;

	public List<Animal> beamAnimals = new List<Animal>();


    void Start()
    {
    	basicCameraRotation		= cam.transform.rotation;
    	basicRotation 			= this.transform.rotation;
    	movementMode 			= ShipMode.Horizontal;
        gyro 					= Input.gyro;
        gyro.enabled 			= true;
        rb 						= transform.parent.gameObject.GetComponent<Rigidbody>();
        ufoRb 					= GetComponent<Rigidbody>();
        beamPoint.gameObject.SetActive(false);
        beamParticles.gameObject.SetActive(false);
        movingParticles.gameObject.SetActive(true);
        StartCoroutine("LowerFuel");
    }

    void Update()
    {
    	if (gameOver) {
    		//Time.timeScale = 0;
    		cam.transform.SetParent(null);
    		cam.transform.RotateAround(this.transform.position, Vector3.up, rotateAngle * Time.deltaTime);
    		UIManager.instance.ActivateGameOver();
    		if (!savedHighScore) {
    			savedHighScore = true;
    			PlayerPrefs.SetInt("highestCount", Stats.GetInstance().money);
    		}
    		return;
    	}

    	//rb.velocity = ufoRb.velocity = Vector3.zero;
    	if (Stats.GetInstance().fuel > 0f) {
	    	switch (movementMode) {
	    		case ShipMode.Horizontal:
			       /* rb.velocity += new Vector3(Input.acceleration.x, 0f, Input.acceleration.y) *Time.deltaTime * 3f * speed;
			        rb.velocity = Vector3.ClampMagnitude(rb.velocity, clampValue);
			        ufoRb.velocity = rb.velocity;
			        RotateShip();*/
			       	if (Input.acceleration.y > delta || Input.acceleration.y < -delta) {
			       		rb.velocity += transform.forward * speed * Input.acceleration.y;
			       	} else {
			       		rb.velocity *= 0.8f;
			       	}
			       	if (Input.acceleration.x > delta || Input.acceleration.x < -delta) {
			       		rb.velocity += transform.right * Input.acceleration.x * speed;
			       	} else {
			       		rb.velocity *= 0.8f;
			       	}
			       	rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
			        rb.velocity = Vector3.ClampMagnitude(rb.velocity, clampValue);
			        ufoRb.velocity = rb.velocity;
			        RotateShip();
	    			break;
	    		case ShipMode.Vertical:
	    			rb.velocity = new Vector3(rb.velocity.x, Input.acceleration.y, rb.velocity.z) * speed;
	    			ufoRb.velocity = rb.velocity;
	    			ufoRb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
	    			if (Input.GetMouseButtonDown(0)) {
	    				beamAnimals.ForEach(animal => {
	    					if (animal.isInBeam) animal.BumpUpwards(beamForce);
	    					else try{
	    						beamAnimals.Remove(animal);
	    					} catch (System.Exception) {}
	    				});
	    			}
	    			ufoRb.constraints = RigidbodyConstraints.None;
	    			break;
	    	}
	    } else {
	    	ufoRb.useGravity = true;
	   	}
    }

    public void ToggleShipMode() {
    	rb.velocity = ufoRb.velocity = Vector3.zero;
    	this.transform.rotation = basicRotation;
    	if (movementMode == ShipMode.Horizontal) {
    		movementMode = ShipMode.Vertical;
    		ActivateBeam();
    		ActivateBeamParticles();
    	}
    	else {
    		movementMode = ShipMode.Horizontal;
    		DeactivateBeam();
    		DeactivateBeamParticles();
    	}
    }

    public void ActivateBeam() {
    	beamPoint.gameObject.SetActive(true);
    }

    public void DeactivateBeam() {
    	beamPoint.gameObject.SetActive(false);
    }

    public void ActivateBeamParticles() {
    	movingParticles.gameObject.SetActive(false);
    	beamParticles.gameObject.SetActive(true);
    }

    public void DeactivateBeamParticles() {
    	movingParticles.gameObject.SetActive(!false);
    	beamParticles.gameObject.SetActive(!true);
    }

    void RotateShip() {
    	this.transform.rotation = Quaternion.Lerp(basicRotation,Quaternion.Euler(new Vector3(ufoRb.velocity.z, 0f, -ufoRb.velocity.x) * 1.33f), tilt);
    }   

    IEnumerator LowerFuel() {
    	while (true) {
    		Stats.GetInstance().ModifyFuel(-1.5f);
    		yield return new WaitForSeconds(1.5f);
    	}
    }
    void OnCollisionEnter(Collision other) {
    	if (other.gameObject.CompareTag("Ground")) {
    		gameOver = true;
    	}

        if (other.gameObject.CompareTag("Cannonball")) {
            Stats.GetInstance().ReduceHealth(1f);
            Destroy(other.gameObject);
        }
    }
}
