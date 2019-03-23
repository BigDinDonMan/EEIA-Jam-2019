using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed;
    public Vector3 direction;
    private bool hasBeenShot = false;

    private void Update() {
    	if (!hasBeenShot) {
    		this.gameObject.GetComponent<Rigidbody>().AddForce(direction * speed);
    		hasBeenShot = true;
    	}
    }

    public void Init(int _damage, float _speed, Vector3 _direction) {
    	damage = _damage;
    	speed = _speed;
    	direction = _direction;
    }
}
