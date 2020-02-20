using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public SpawnManagerScriptableObject ObjectToSpawn;
    public Transform SpawnLocation;
    public float objectSizeMax = 2.5f;
    public float objectSizeMin = 1f;
    public Transform[] spawnLocations;

    //time sensative floats
    public float dropForkTime;
    public float spawnWait;

    //fork object for dropping
    public GameObject fork;

    //let player know fork dropped (stop running active function)
    public bool forkDropped;

    // Use this for initialization
    void Start () {
        fork.SetActive(false);
        InvokeRepeating("GenerateObject", Random.Range(0,4),spawnWait);
	}

    public void Update()
    {
        //if its been long enough, reactivate the fork
        if(Time.realtimeSinceStartup >= dropForkTime && !forkDropped)
        {
            fork.SetActive(true);
            forkDropped = true;
            print("the FORK has been dropped! Activate Audio HERE!");
        }
    }

    public void GenerateObject()
    {
        Instantiate(ObjectToSpawn.prefab, spawnLocations[Random.Range(0,3)].position, transform.rotation * Quaternion.Euler(-90f, 0f, 0f));
        //ObjectToSpawn.transform.localScale = Vector3.one * Random.Range(objectSizeMin, objectSizeMax);
    }
}
