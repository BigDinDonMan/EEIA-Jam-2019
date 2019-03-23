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

	public ShipMode movementMode;

	public Quaternion basicRotation;
	public Quaternion basicCameraRotation;

	public Camera cam;

	public Vector3 offset;

	public float rotateAngle;


    void Start()
    {
    	basicCameraRotation		= cam.transform.rotation;
    	basicRotation 			= this.transform.rotation;
    	movementMode 			= ShipMode.Horizontal;
        gyro 					= Input.gyro;
        gyro.enabled 			= true;
        rb 						= transform.parent.gameObject.GetComponent<Rigidbody>();
        ufoRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
    	switch (movementMode) {
    		case ShipMode.Horizontal:
		        rb.velocity = new Vector3(Input.acceleration.x, 0f, Input.acceleration.y) * Mathf.Pow(speed, 2) / 1.5f;// * Time.deltaTime;
		        ufoRb.velocity = rb.velocity;
    			break;
    		case ShipMode.Vertical:
    			rb.velocity = Vector3.zero;
    			rb.velocity = new Vector3(rb.velocity.x, Input.acceleration.y, rb.velocity.z) * speed;
    			ufoRb.velocity = rb.velocity;
    			break;
    	}
    	RotateShip();
    }

    public void ToggleShipMode() {
    	if (movementMode == ShipMode.Horizontal) movementMode = ShipMode.Vertical;
    	else movementMode = ShipMode.Horizontal;
    }

    void RotateShip() {
    	this.transform.rotation = Quaternion.Lerp(basicRotation, Quaternion.Euler(new Vector3(ufoRb.velocity.z, 0f, -ufoRb.velocity.x)), 0.55f);
    }

    
}
