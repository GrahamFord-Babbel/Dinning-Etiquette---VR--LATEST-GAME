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
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void DadScored(int points)
    {
        //increment score 1 higher    
        dadScore = dadScore + points;
    }
    public void BabyScored(int points)
    {
        //increment score 1 higher    
        dadScore = dadScore + points;
    }
}
