using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    //Script Purpose: To collect the current score from ScoreKeeper and display it for the user

    public ScoreKeeper scoreKeeper;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        //scoreKeeper = FindObjectOfType<ScoreKeeper>();
        //scoreText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //update the display to count updated score
        scoreText.text = "Baby's Score: " + scoreKeeper.gameScore;
	}
}
