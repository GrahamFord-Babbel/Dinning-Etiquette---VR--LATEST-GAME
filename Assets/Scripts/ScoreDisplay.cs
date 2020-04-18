using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Normal.Realtime;

//Job Summary- To collect the current score from ScoreKeeper and display it for the user
public partial class ScoreDisplay: MonoBehaviour
{
    //use these variables collected from other scripts to display Score & Time in in-game UI
    public ScoreKeeper scoreKeeper;
    public Text scoreText;
    public Text timeText;

    public float gameScore;
	
	// Update is called once per frame
	void Update ()
    {
        //only change score if actually changed
        if(gameScore != scoreKeeper.gameScore)
        {
            gameScore = scoreKeeper.gameScore;
        }

        //update the display to count updated score
        scoreText.text = "Baby's Score: " + gameScore;
        timeText.text = "Time Remaining: " + scoreKeeper.timeRemaining;
    }
}
