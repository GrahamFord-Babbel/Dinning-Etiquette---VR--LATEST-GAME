﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHasHit : MonoBehaviour
{
    //get scoreKeeper
    public ScoreKeeper scoreKeeper;
    public GameObject dadPlayer;
    public GameObject babyPlayer;
    public GameObject enVironment;
    private GameObject collisionObject;

    //NOTE: THESE ARE SUPER REPEATATIVE CODE PIECES, CAN WE COMBINE THEM INTO 1?

    //will be used for changing scores that hit players
    public void OnTriggerEnter(Collider other)
    {
        //stores the object using that objects collider
        collisionObject = other.gameObject;

        //checks to see if the object that collided with Dad originated from the Spawner
        if (collisionObject.tag == "BabyCollectible")
        {
            //for when object hits dad
            if (this.gameObject == dadPlayer) //make this tag type player
            {
                //Increment Dad Score - get IncrementScore by __ from ScoreKeeper - specific to the Gameobjects Points (Negative or Positive)
                //scoreKeeper.Scored("dadScore", 1);
                scoreKeeper.DadScored(1);

                //checks to see if of type increase is working
                Debug.Log("Dad Score Increased!");

                //remove the CollectibleObjects once collected
                Destroy(collisionObject);
            }
        }
    }

    //will be used for changing scores that hit environment
    public void OnTriggerExit(Collider other)
    {
        //stores the object using that objects collider
        collisionObject = other.gameObject;

        //checks to see if the object that collided with Dad originated from the Spawner
        if (collisionObject.tag == "BabyCollectible")
        {
            //for when object hits ground
            if (this.gameObject == enVironment)
            {
                //Increment Dad Score - get IncrementScore by __ from ScoreKeeper - specific to the Gameobjects Points (Negative or Positive)
                //scoreKeeper.Scored("babyScore", 1);
                scoreKeeper.BabyScored(1);

                //checks to see if of type increase is working
                Debug.Log(enVironment.name + " for Baby Score Increase");
            }
        }
    }


    //public void ScoreSequence(GameObject collisionObject)
    //{

    //    //checks to see if the object that collided with Dad originated from the Spawner
    //    if (collisionObject.tag == "BabyObject")
    //    {
    //        //for when object hits dad
    //        if (this.gameObject == dadPlayer) //make this tag type player
    //        {
    //            //Increment Dad Score - get IncrementScore by __ from ScoreKeeper - specific to the Gameobjects Points (Negative or Positive)
    //            //scoreKeeper.Scored("dadScore", 1);
    //            scoreKeeper.DadScored(1);

    //            //checks to see if of type increase is working
    //            Debug.Log("Dad Score Increased!");
    //        }
    //        //for when object hits ground
    //        else if(this.gameObject == enVironment)
    //        {
    //            //Increment Dad Score - get IncrementScore by __ from ScoreKeeper - specific to the Gameobjects Points (Negative or Positive)
    //            //scoreKeeper.Scored("babyScore", 1);
    //            scoreKeeper.BabyScored(1);

    //            //checks to see if of type increase is working
    //            Debug.Log(enVironment.name + " for Baby Score Increase");
    //        }

    //        //use switch for the score keeping for how it effects the score depending on the object that hit Dad?
    //        //switch (switch_on)
    //        //{
    //        //    default:
    //        //}

    //    }
    //}

}
