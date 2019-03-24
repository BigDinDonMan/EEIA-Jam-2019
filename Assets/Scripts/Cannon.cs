using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Cannon : MonoBehaviour
{
    private Transform shootpoint;
    public GameObject cannonballPrefab;

    public float shotTimer = 0f;
	public Transform player;
    void Start()
    {
        shotTimer = 0f;
        player = GameObject.FindWithTag("Player").transform;
        shootpoint = transform.GetChild(0);
    }

    void Update()
    {
        transform.LookAt(player);
        if (shotTimer > 10f && Vector3.Distance(this.transform.position, player.position) < 30f)
        {
            GameObject go = Instantiate(cannonballPrefab, shootpoint.position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
            //go.GetComponent<Rigidbody>().velocity = new Vector3(player.position.x - shootpoint.position.x, player.position.y - shootpoint.position.y + (player.position.x - shootpoint.position.x) / 3 + (player.position.z - shootpoint.position.z) / 3, player.position.z - shootpoint.position.z).normalized * 20f;
            go.GetComponent<Bullet>().Init(new Vector3(player.position.x - shootpoint.position.x, player.position.y - shootpoint.position.y /*+ (player.position.x - shootpoint.position.x) / 3 + (player.position.z - shootpoint.position.z) / 3*/, player.position.z - shootpoint.position.z).normalized * 15f);
            shotTimer = 0f;
        }
        shotTimer += Time.deltaTime;

    }
}
