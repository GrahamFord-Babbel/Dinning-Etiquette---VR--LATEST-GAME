using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {


    //Script Purpose: Keeps track of how many zombies have been killed

    public float dadScore;
    public float babyScore;

    void Start ()
    {
        DontDestroyOnLoad(gameObject);

	}
	
    //FIGURE OUT HOW TO MAKE THIS CONDENSED VERSION OF THE TWO WORK:
    //public void Scored(string who, int points)
    //{
    //        who = who + points;

    //   // -delete all this if "who" works

    //    ////increment score 1 higher    
    //    //dadScore = dadScore + points;
    //}

    public void DadScoreChanged(int points)
    {
        //increment score 1 higher    
        dadScore = dadScore + points;
    }
    public void BabyScoreChanged(int points)
    {
        //increment score 1 higher    
        babyScore = babyScore + points;
    }
}
