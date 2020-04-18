using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    //Script Purpose: To create a countdown clock that respawns zombies

    public GameObject zombieAgent;
    public float timeDifficulty;
    public float timeCounter;
    public GameObject[] randomSpawnLocations;
    public int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        randomSpawnLocations = GameObject.FindGameObjectsWithTag("SpawnLocation");
        timeCounter = timeDifficulty;
    }

    // Update is called once per frame
    void Update()
    {
        //if the count down reaches 0, respawn another zombie
        if (timeCounter <= 0)
        {

            //select one of the random spawn locations
            randomNumber = Random.Range(0, 4);
            Debug.Log("The exact random location is: " + randomNumber);

            //spawn at chosen random location
            Instantiate(zombieAgent, randomSpawnLocations[randomNumber].transform.position, randomSpawnLocations[randomNumber].transform.rotation);

            //reset counter to the original time
            timeCounter = timeDifficulty;
        }

        //start countdown
        timeCounter = timeCounter - Time.deltaTime;

    }
}
