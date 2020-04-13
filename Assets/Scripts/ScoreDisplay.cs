using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Normal.Realtime.Serialization;

[RealtimeModel]
public class ScoreDisplay: MonoBehaviour
{

    //Script Purpose: To collect the current score from ScoreKeeper and display it for the user

    public ScoreKeeper scoreKeeper;
    public Text scoreText;
    public Text timeText;

    //display score
    [RealtimeProperty(1,false,true)]
    private float _gameScore;

    // Use this for initialization
    void Start () {
        //scoreKeeper = FindObjectOfType<ScoreKeeper>();
        //scoreText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //adjust gameScore from ScoreKeeper to here (because NORMCORE private restriction)
        _gameScore = scoreKeeper.gameScore;

        //update the display to count updated score
        scoreText.text = "Baby's Score: " + _gameScore;
        timeText.text = "Time Remaining: " + scoreKeeper.timeRemaining;
    }
}
