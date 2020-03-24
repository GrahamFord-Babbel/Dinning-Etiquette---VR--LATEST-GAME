using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour
{
    //reason this is a float?
    public float gameScore;
    public float timeRemaining;


    //reset score if object data is persisting
    public void Start()
    {
        gameScore = 0;

        //can access private
    }
}
