using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour
{


    //Script Purpose: Keeps track of how many zombies have been killed

    public float dadScore; //delete when done with EventBus
    public float babyScore; //delete when done with EventBus
    public float gameScore;

    //reset score if object data is persisting
    public void Start()
    {
        gameScore = 0;
    }

    //DELETE WHEN CONFIRMED CLEAR
    //public void DadScoreChanged(int points)
    //{
    //    //increment score 1 higher    
    //    dadScore = dadScore + points;
    //}
    //public void BabyScoreChanged(int points)
    //{
    //    //increment score 1 higher    
    //    babyScore = babyScore + points;
    //}
}
