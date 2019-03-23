using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipRotation : MonoBehaviour
{
    public float rotationValue;
    public Transform player;

    public void RotateLeft() {
    	player.Rotate(0f, -rotationValue, 0f);
    }

    public void RotateRight() {
    	player.Rotate(0f, rotationValue, 0f);
    }

    private IEnumerator RotatingLeft() {
    	while (true) {
    		RotateLeft();
    		yield return new WaitForSeconds(0.02f);
    	}
    }

    private IEnumerator RotatingRight() {
    	while (true) {
    		RotateRight();
    		yield return new WaitForSeconds(0.02f);
    	}
    }

    public void StartRotatingLeft() {
    	StartCoroutine("RotatingLeft");
    }

    public void StartRotatingRight() {
    	StartCoroutine("RotatingRight");
    }

    public void StopRotatingLeft() {
    	StopCoroutine("RotatingLeft");
    }

    public void StopRotatingRight() {
    	StopCoroutine("RotatingRight");
    }
}
