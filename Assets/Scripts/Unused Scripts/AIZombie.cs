using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIZombie : MonoBehaviour
{

    //Script Purpose: To apply AI to enemy zombies, so they can randomly attack player (increasing difficulty overtime)

    //collect the zombie and player details
    private NavMeshAgent ThisZombieAgent = null;
    public Transform Player;

    //increase difficulty as time progresses
    float difficultyTimeCounter;
    public float easy;
    public float medium;
    public float hard;

    // Start is called before the first frame update
    void Start()
    {
        ThisZombieAgent = GetComponent<NavMeshAgent>();
        difficultyTimeCounter = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        //move the zombie to the player location
        if(this.name != "TheOriginalZombie")
        {
            //keep track of time
            difficultyTimeCounter = difficultyTimeCounter + Time.deltaTime;
            //Debug.Log(difficultyTimeCounter);

            //if time past easy, establish new AI speed
            if (difficultyTimeCounter > easy && difficultyTimeCounter < medium && difficultyTimeCounter < hard)
            {
                ThisZombieAgent.speed = 0.5f;
                ThisZombieAgent.SetDestination(Player.position);
            }

            //if time past medium, establish new AI speed
            if (difficultyTimeCounter > medium && difficultyTimeCounter < hard)
            {
                ThisZombieAgent.speed = 1;
                ThisZombieAgent.SetDestination(Player.position);
            }

            //if time past hard, establish new AI speed
            else if (difficultyTimeCounter > hard)
                {
                    ThisZombieAgent.speed = 3;
                    ThisZombieAgent.SetDestination(Player.position);
                }

            //for this section, I would utilize a LOOP so as to combine all these IF statements, but for the lack of time I've broken them out
            
        }

    }
}
