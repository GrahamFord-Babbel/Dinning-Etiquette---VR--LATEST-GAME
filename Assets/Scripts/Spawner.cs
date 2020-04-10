using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Spawner : MonoBehaviour {

    //get normcore tools
    private Realtime _realtime;
    public bool connectedSpawn;

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

    private void Awake()
    {
        // Get the Realtime component on this game object
        _realtime = GetComponent<Realtime>();

        _realtime.didConnectToRoom += DidConnectToRoom;
    }

    // Use this for initialization
    void Start () {
        //disable the fork
        fork.SetActive(false);

        // Notify us when Realtime successfully connects to the room
        _realtime.didConnectToRoom += DidConnectToRoom;
	}

    public void Update()
    {
        //NORMCORE - Multiplayer Script - if connected Spawn Objects
        if (connectedSpawn)
        {

            //Generate Bottle Objects - Rapid Prototyping (UPDATE to Object Pooling ASAP)
            InvokeRepeating("GenerateObject", Random.Range(0, 4), spawnWait);
            connectedSpawn = false;
        }
        //if its been long enough, reactivate the fork
        if (Time.realtimeSinceStartup >= dropForkTime && !forkDropped)
        {
            fork.SetActive(true);
            forkDropped = true;
            print("the FORK has been dropped! Activate Audio HERE!");
        }
    }

    //NORMCORE - Multiplayer Script
    private void DidConnectToRoom(Realtime realtime)
    {
        connectedSpawn = true;
    }


    public void GenerateObject()
    {
        //removing this version of instantiate to make room for the multiplayer version
        //Instantiate(ObjectToSpawn.prefab, spawnLocations[Random.Range(0,3)].position, transform.rotation * Quaternion.Euler(-90f, 0f, 0f));
        //ObjectToSpawn.transform.localScale = Vector3.one * Random.Range(objectSizeMin, objectSizeMax);

        //NORMCORE - Multiplayer Script for Instantiation
        Realtime.Instantiate("BabyBottle",                 // Prefab name
                                position: spawnLocations[Random.Range(0, 3)].position,          // Start 1 meter in the air
                                rotation: transform.rotation * Quaternion.Euler(-90f, 0f, 0f), // No rotation
                           ownedByClient: false,   // Make sure the RealtimeView on this prefab is owned by this client
               preventOwnershipTakeover: true,                // Prevent other clients from calling RequestOwnership() on the root RealtimeView.
                            useInstance: _realtime);
    }
}
