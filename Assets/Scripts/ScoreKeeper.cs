using UnityEngine;
using System.Collections;
using Normal.Realtime;

//Job Summary - change the private score value of our Realtime Component based on the actions in EvenBusScorer
public class ScoreKeeper : RealtimeComponent
{
    //a public instance of the gameScore so ScoreDisplay can access the value
    //TODO - dig into the reason you initially set this up as Floats
    public float gameScore;

    //to display how much time the players have till the game ends
    public float timeRemaining;

    //the Realtime Model thats used to hold the score over the Network - has been setup in its own script due to Normcore protocol 
    private RealtimeScoreModel _model;

    //due to the redundancy of using 2 instances of gameScore, using this bool to reset the private NORMCORE version to 0 using the public local value
    private bool doOnce;

    public void Start()
    {
        //reset score if object data is persisting from previous game
        gameScore = 0;
    }

    //set the realtime Score Model to be recognized as value - NORMCORE protocol
    private RealtimeScoreModel model
    {
        set
        {
            // Store the model
            _model = value;
        }
    }

    //alters the private value of gameScore on the Realtime model to update Network
    public void Scored(int points)
    {

        //to handle reseting the value to 0 on start (once connected to network)
        if (!doOnce)
        {
            _model.gameScore = gameScore;
            doOnce = true;
        }

        //gets points from EventBusScorer to update Network score - TODO - remove reduncancy of gameScore (find solution)
        _model.gameScore += points;
        gameScore = _model.gameScore;
    }
}
