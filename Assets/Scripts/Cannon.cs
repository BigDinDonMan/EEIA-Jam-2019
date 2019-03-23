using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Cannon : MonoBehaviour
{
	public float shotTimer = 0f;
	public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        shotTimer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot() {
    	if (shotTimer > 0f) return;

    }
}
