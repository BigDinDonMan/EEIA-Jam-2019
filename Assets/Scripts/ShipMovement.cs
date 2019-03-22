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

	public float speed;

	public ShipMode movementMode;

	public Quaternion basicRotation;
	public Quaternion basicCameraRotation;

	public Camera cam;

    void Start()
    {
    	cam 					= GetComponentInChildren<Camera>();
    	basicCameraRotation		= cam.transform.rotation;
    	basicRotation 			= this.transform.rotation;
    	movementMode 			= ShipMode.Horizontal;
        gyro 					= Input.gyro;
        gyro.enabled 			= true;
        rb 						= GetComponent<Rigidbody>();
    }

    void Update()
    {
    	if (Input.GetMouseButtonDown(0)) {
    		ToggleShipMode();
    	}
    	switch (movementMode) {
    		case ShipMode.Horizontal:
		        rb.velocity = new Vector3(Input.acceleration.x, 0f, Input.acceleration.y) * Mathf.Pow(speed, 2) / 1.5f;// * Time.deltaTime;
    			break;
    		case ShipMode.Vertical:
    			rb.velocity = Vector3.zero;
    			rb.velocity = new Vector3(rb.velocity.x, Input.acceleration.y, rb.velocity.z) * speed;
    			break;
    	}
    	RotateShip();
    }

    void ToggleShipMode() {
    	if (movementMode == ShipMode.Horizontal) movementMode = ShipMode.Vertical;
    	else movementMode = ShipMode.Horizontal;
    }

    void RotateShip() {
    	this.transform.rotation = Quaternion.Lerp(basicRotation, Quaternion.Euler(rb.velocity), 0.1f);
    	cam.transform.rotation = basicCameraRotation;
    }
}
