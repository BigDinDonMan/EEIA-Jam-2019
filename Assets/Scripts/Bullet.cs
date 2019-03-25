using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public int damage;
    private float destroyTimer = 0f;
    public Vector3 direction = Vector3.zero;
    private bool boolean_doopy = false;
    //public float speed;
    //public Vector3 direction;
    //private bool hasBeenShot = false;

    private void Update() {
        if (destroyTimer > 5f)
        {
            Destroy(this.gameObject);
        }
        destroyTimer += Time.deltaTime;

        this.transform.position += direction * Time.deltaTime;
        this.transform.position -= Vector3.down * Time.deltaTime;
    	/*if (!hasBeenShot) {
    		this.gameObject.GetComponent<Rigidbody>().AddForce(direction * speed);
    		hasBeenShot = true;
    	}*/

    }

    public void Init(/*int _damage, float _speed, */Vector3 _direction) {
    	//damage = _damage;
    	//speed = _speed;
    	direction = _direction;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (boolean_doopy) return;
            boolean_doopy = true;
            Stats.GetInstance().ReduceHealth(1f);
            Destroy(this.gameObject);
        }
    }
}
