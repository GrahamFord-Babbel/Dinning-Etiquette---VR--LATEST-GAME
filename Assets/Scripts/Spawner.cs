using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public SpawnManagerScriptableObject ObjectToSpawn;
    public Transform SpawnLocation;
    public float objectSizeMax = 2.5f;
    public float objectSizeMin = 1f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("GenerateObject", Random.Range(0,4),4);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void GenerateObject()
    {
        Instantiate(ObjectToSpawn.prefab, ObjectToSpawn.spawnPoints[Random.Range(0,3)], transform.rotation);
        //ObjectToSpawn.transform.localScale = Vector3.one * Random.Range(objectSizeMin, objectSizeMax);
    }
}
