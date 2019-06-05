using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{

	public GameObject[] cowPrefabs = null;

	public float cowSpawnTimer = 0f;

	public float range;

    public static int highestCount;

    public Transform[] crystalSpawnPoints;

    public GameObject crystal;

    public int cowAmount = 0;

    // Start is called before the first frame update
    void Start(){
        if (PlayerPrefs.HasKey("highestCount")) {
            highestCount = PlayerPrefs.GetInt("highestCount");
        }
    	cowPrefabs = Resources.LoadAll("Prefab/Cows", typeof(GameObject)).Cast<GameObject>().ToArray();
        cowAmount = Random.Range(25, 70);
        for (int i = 0; i < cowAmount; ++i) {
            Transform temp = crystalSpawnPoints[Random.Range(0, crystalSpawnPoints.Length)];
        	Instantiate(
        		cowPrefabs[Random.Range(0, cowPrefabs.Length)],
        		new Vector3(temp.position.x + Random.Range(-range, range), temp.position.y, temp.position.z + Random.Range(-range, range)),
        		Quaternion.identity
        	);
        }
        cowSpawnTimer = 5f;

        foreach (var spawnPoint in crystalSpawnPoints) {
            int amount = Random.Range(2, 5);
            for (int i = 0; i < amount; ++i) {
                Instantiate(crystal, new Vector3(spawnPoint.position.x + Random.Range(-10f, 10f), spawnPoint.position.y, spawnPoint.position.z + Random.Range(-10f, 10f)), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update(){   
        if (!ShipMovement.gameOver) {
            cowSpawnTimer -=Time.deltaTime;
            if (cowSpawnTimer <= 0f) {
            	cowSpawnTimer = 5f;
            	Instantiate(
            		cowPrefabs[Random.Range(0, cowPrefabs.Length)], new Vector3(
            			this.transform.position.x + Random.Range(-range, range), 
            			this.transform.position.y, 
            			this.transform.position.z + Random.Range(-range, range)
            		),
            		Quaternion.identity
            	);
            }
            cowAmount++;
        }
    }

    public static void ResetStaticVars() {
        GameManager.highestCount = 0;
        ShipMovement.gameOver = false;
    }
}
