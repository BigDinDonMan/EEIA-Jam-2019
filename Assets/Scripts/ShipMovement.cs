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

    void Start()
    {
    	movementMode = ShipMode.Horizontal;
        gyro = Input.gyro;
        gyro.enabled = true;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
    	if (Input.GetMouseButtonDown(0)) {
    		ToggleShipMode();
    	}
    	switch (movementMode) {
    		case ShipMode.Horizontal:
		        rb.velocity = new Vector3(Input.acceleration.x, 0f, Input.acceleration.y) * Mathf.Pow(speed, 2) / 2;// * Time.deltaTime;
    			break;
    		case ShipMode.Vertical:
    			rb.velocity = Vector3.zero;
    			rb.velocity = new Vector3(rb.velocity.x, Input.acceleration.y, rb.velocity.z);
    			break;
    	}
    }

    void ToggleShipMode() {
    	if (movementMode == ShipMode.Horizontal) movementMode = ShipMode.Vertical;
    	else movementMode = ShipMode.Horizontal;
    }
}
