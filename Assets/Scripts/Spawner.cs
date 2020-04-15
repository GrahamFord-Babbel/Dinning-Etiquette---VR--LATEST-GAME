﻿using System.Collections;
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
    public GameObject babyBottle;

    //fork object for dropping
    public GameObject fork;

    //let player know fork dropped (stop running active function)
    public bool forkDropped;

    //Game Object throwing list
    public List<GameObject> throwList;
    //create a amount for the list (adjustable)
    [Range(0,50)]
    public int bottleStartAmount;

    //bool of if all bottles active to stop coroutine
    public bool allBottlesActive;
    public int countActive;
    public bool oneSetActive;

    //hold random value - to prevent instantiating in same position
    public int previousRange;
    public int nextRandomRange;

    private IEnumerator coroutine;

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

        //TODO: is there a way to put the PoolSystem here - not really because this script doesnt activate till player presses P?
        //coroutine = TestRoutine(spawnWait);
        //StartCoroutine(coroutine);
    }

    public void Update()
    {
        //HAS RACE CONDITION with DIDCONNECTTOROOM in start 4.11
        if (connectedSpawn)
        {

            //Generate Bottle Objects - Rapid Prototyping (UPDATE to Object Pooling ASAP)
            // InvokeRepeating("GenerateObject", Random.Range(0, 4), spawnWait);

            //create usable list of throwable objects
            PoolSystem(bottleStartAmount);
            print("PoolHappened");

            //activate bottles every spawnWait time
            //InvokeRepeating("ActivateBottles", Random.Range(0, 4), spawnWait);

            //coroutine = ActivateObjectsTimer(spawnWait);
            StartCoroutine(ActivateObjectsTimer(spawnWait));

            connectedSpawn = false;
        }


        if (allBottlesActive == true)
        {
            //StopCoroutine
            print("COROUTINE STOPPED");
            StopCoroutine(ActivateObjectsTimer(spawnWait));
        }

        ////NORMCORE - Multiplayer Script - if connected Spawn Objects
        //if (connectedSpawn)
        //{

        //    //Generate Bottle Objects - Rapid Prototyping (UPDATE to Object Pooling ASAP)
        //    // InvokeRepeating("GenerateObject", Random.Range(0, 4), spawnWait);
        //    // TODO - Revert this if pool system fails
        //    connectedSpawn = false;
        //}
        //if its been long enough, reactivate the fork
        if (Time.realtimeSinceStartup >= dropForkTime && !forkDropped)
        {
            fork.SetActive(true);
            forkDropped = true;
            print("the FORK has been dropped! Activate Audio HERE!");
        }

        else //when object is picked up by Dad, allBottlesActive set to false
        {
            //StartCoroutine
            //StartCoroutine(ActivateObjectsTimer(spawnWait));
        }
    }

    //NORMCORE - Multiplayer Script
    private void DidConnectToRoom(Realtime realtime)
    {
        connectedSpawn = true;
    }


    public GameObject GenerateObject()
    {
        //removing this version of instantiate to make room for the multiplayer version
        //Instantiate(ObjectToSpawn.prefab, spawnLocations[Random.Range(0,3)].position, transform.rotation * Quaternion.Euler(-90f, 0f, 0f));
        //ObjectToSpawn.transform.localScale = Vector3.one * Random.Range(objectSizeMin, objectSizeMax);

        //NORMCORE - Multiplayer Script for Instantiation
        babyBottle =  Realtime.Instantiate("BabyBottle",                 // Prefab name
                                position: transform.position,          // Start 1 meter in the air
                                rotation: transform.rotation * Quaternion.Euler(-90f, 0f, 0f), // No rotation
                           ownedByClient: false,   // Make sure the RealtimeView on this prefab is owned by this client
               preventOwnershipTakeover: false,                // Prevent other clients from calling RequestOwnership() on the root RealtimeView.
                            useInstance: _realtime);

        return babyBottle;
    }

    public void PoolSystem(int amount)
    {
        throwList = new List<GameObject>();
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = GenerateObject();
            throwList.Add(obj);
            obj.SetActive(false);
        }
    }

    public void ActivateBottles()
    {
            RandomizeSpawn();

        ////set position
        //throwList[0].gameObject.transform.position = spawnLocations[nextRandomRange].position;

        ////add object back to Baby Table
        //throwList[0].SetActive(true);

        //TODO - use this for something fun
        foreach (GameObject bottle in throwList)
        {

            //    for (int i = 0; i < throwList.Count; i++)
            //    { 
            //        if (throwList[i].activeSelf == true)
            //        {
            //            countActive++;
            //        }
            //}
            if (bottle.activeSelf == false && oneSetActive == false)
            {
                //bottle.GetComponent<CubePl>
                //._realtimeTransform.RequestOwnership();

                //disable NORMCORE RT so you can relocate the object, will renable
                //bottle.GetComponent<RealtimeTransform>().enabled = false;
                bottle.GetComponent<RealtimeTransform>().RequestOwnership();
                //relocate object - TODO: Need to add Realtime Transform to this somehow
                bottle.transform.position = spawnLocations[nextRandomRange].position;
                bottle.transform.rotation = transform.rotation * Quaternion.Euler(-90f, 0f, 0f);
                bottle.SetActive(true);
                //stop the pattern to repeat activating bottles
                oneSetActive = true;
            }

            //if (bottle.activeSelf == false // &&count)
            //{
            //    bottle.transform.position = spawnLocations[nextRandomRange].position;
            //    bottle.transform.rotation = transform.rotation * Quaternion.Euler(-90f, 0f, 0f);
            //    bottle.SetActive(true);
            //}
            //if the last bottle is active, assume all bottles active (bad logic- TODO: Think better logic)
            if(throwList[throwList.Count-1].activeSelf)
                {
                print("THROW LIST COOUNT:" + (throwList.Count - 1));
                allBottlesActive = true;
                countActive = 0;
                }
            else
            {
                print("doing nothing");
            }
            //THIS IS NOT DOING ANYTHING - being ignored
            //return;
        }
        //return;
    }

    void RandomizeSpawn()
    {
        //create a random number
        nextRandomRange = Random.Range(0, 3);

        //keep calculating random until not same as previous
        while (previousRange == nextRandomRange)
        {
            nextRandomRange = Random.Range(0, 3);
        }

        //set previous number to be the number just used
        previousRange = nextRandomRange;
    }

    // every x seconds perform the print()
    private IEnumerator ActivateObjectsTimer(float waitTime)
    {
        while (true)
        {
            ActivateBottles();
            yield return new WaitForSeconds(waitTime);
            //allow the pattern to repeat activating bottles
            oneSetActive = false;
            print("coroutine STILL running");
        }
    }

    private IEnumerator TestRoutine (float waitTime)
    {
        //needs while TRUE to function
        print("coroutine 2 STILL running");
        yield return new WaitForSeconds(waitTime);
        print("coroutine 3 STILL running");
    }

    }
