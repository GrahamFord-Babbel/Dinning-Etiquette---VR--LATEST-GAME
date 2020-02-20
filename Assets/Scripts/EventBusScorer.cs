using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBusScorer : MonoBehaviour
{

    //get scoreKeeper
    public ScoreKeeper scoreKeeper;

    //get player objects that can be Hit
    public GameObject dadPlayer;
    public GameObject babyPlayer;
    public GameObject enVironment;
    public GameObject forkZone;

    //provide a value to control Score change
    private int pointsChanged;

    //determine what value pointsChange should be based on data from collision events
    public void AssessScoreChange(GameObject objectHit, GameObject objectHitter)
    {
        //points based on if object hit Dad
        if (objectHit == dadPlayer)
        {
            if (objectHitter.tag == "BabyCollectible")
            {
                pointsChanged = 1;
            }
            else if (objectHitter.tag == "BabyWeapon")
            {
                pointsChanged = -1;
            }

            //destroy obj
            Destroy(objectHitter);

            Debug.Log("Points changed because " + objectHitter + "hit " + objectHit);
        }

        //points based on if object hit forkzone
        else if (objectHit == forkZone)
        {
            if (objectHitter.tag == "BabyCollectible")
            {
                pointsChanged = 1;
            }
            else if (objectHitter.tag == "BabyWeapon")
            {
                pointsChanged = -1;
            }
            //destroy obj
            Destroy(objectHitter);

            Debug.Log("Points changed because " + objectHitter + "hit " + objectHit);
        }

        //points based on if object hit environment
        else if (objectHit == enVironment)
        {
            if (objectHitter.tag == "BabyCollectible" || objectHitter.tag == "BabyWeapon")
            {
                pointsChanged = 1;
            }
            //destroy obj
            Destroy(objectHitter);

            Debug.Log("Points changed because " + objectHitter + "hit " + objectHit);
        }

        //points based on if object hit baby
        else if (objectHit == babyPlayer)
        {
            print("Who would hit a baby!");
        }

        //once points to change score have been calculated, change the score
        Scored(pointsChanged);
    }

    //FIGURE OUT HOW TO MAKE THIS CONDENSED VERSION OF THE TWO WORK:
    public void Scored(int points)
    {
        scoreKeeper.gameScore += points;
    }
}
    
