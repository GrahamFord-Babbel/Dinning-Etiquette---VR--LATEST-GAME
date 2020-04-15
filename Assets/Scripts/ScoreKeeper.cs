using UnityEngine;
using System.Collections;
using Normal.Realtime;

public class ScoreKeeper : RealtimeComponent
{
    //reason this is a float?
    public float gameScore;
    public float timeRemaining;

    //get the Realtime Score Model
    private RealtimeScoreModel _model;

    private bool doOnce;


    //addd the score model here

    //reset score if object data is persisting
    public void Start()
    {
        gameScore = 0;
        //^change above to be reflective of the synced model...
        //doint think i can do this witthout doing the below set function
        //_model.gameScore = 0;
    }

    ////set the realtime Score Model to be recognized as value - is this needed?
    private RealtimeScoreModel model
    {
        set
        {
            // Store the model
            _model = value;
        }
    }

    public void Scored(int points)
    {

        //to handle reseting the value to 0 on start (once connected to network)
        if (!doOnce)
        {
            _model.gameScore = gameScore;
            doOnce = true;
        }

        //TODO- change the score model here
        //something like: 
        _model.gameScore += points;
        gameScore = _model.gameScore;

        //delete this
        //scoreKeeper.gameScore += points;
    }
}
