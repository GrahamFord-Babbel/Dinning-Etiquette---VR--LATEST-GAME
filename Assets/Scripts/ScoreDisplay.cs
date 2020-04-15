using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Normal.Realtime;

public partial class ScoreDisplay: MonoBehaviour
{

    //Script Purpose: To collect the current score from ScoreKeeper and display it for the user

    public ScoreKeeper scoreKeeper;
    public Text scoreText;
    public Text timeText;

    public float gameScore;

    // Use this for initialization
    void Start () {
        //scoreKeeper = FindObjectOfType<ScoreKeeper>();
        //scoreText = GetComponent<Text>();

        //_scoreKeeper = GetComponent<ScoreKeeper>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //adjust gameScore from ScoreKeeper to here (because NORMCORE private restriction)
        //TODO- somehow collect the Score Model's Score data when it changes
        //gameScore = _scoreModel;

        //added condition of this 4.14 after sync was working, if broken LOOK HERE
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
