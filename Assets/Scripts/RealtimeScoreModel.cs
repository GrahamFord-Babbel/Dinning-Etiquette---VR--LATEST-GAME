using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime.Serialization;

//Job Summary - mantains the Network value of score
[RealtimeModel]
public partial class RealtimeScoreModel
{
    //network score for NORMCORE database
    [RealtimeProperty(1, false, true)]
    private float _gameScore;
}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class RealtimeScoreModel : IModel {
    // Properties
    public float gameScore {
        get { return _gameScore; }
        set { if (value == _gameScore) return; _gameScoreShouldWrite = true; _gameScore = value; FireGameScoreDidChange(value); }
    }
    
    // Events
    public delegate void GameScoreDidChange(RealtimeScoreModel model, float value);
    public event         GameScoreDidChange gameScoreDidChange;
    
    private bool _gameScoreShouldWrite;
    
    public RealtimeScoreModel() {
    }
    
    // Events
    public void FireGameScoreDidChange(float value) {
        try {
            if (gameScoreDidChange != null)
                gameScoreDidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    
    // Serialization
    enum PropertyID {
        GameScore = 1,
    }
    
    public int WriteLength(StreamContext context) {
        int length = 0;
        
        if (context.fullModel) {
            // Write all properties
            length += WriteStream.WriteFloatLength((uint)PropertyID.GameScore);
        } else {
            // Unreliable properties
            if (context.unreliableChannel) {
                if (_gameScoreShouldWrite) {
                    length += WriteStream.WriteFloatLength((uint)PropertyID.GameScore);
                }
            }
        }
        
        return length;
    }
    
    public void Write(WriteStream stream, StreamContext context) {
        if (context.fullModel) {
            // Write all properties
            stream.WriteFloat((uint)PropertyID.GameScore, _gameScore);
            _gameScoreShouldWrite = false;
        } else {
            // Unreliable properties
            if (context.unreliableChannel) {
                if (_gameScoreShouldWrite) {
                    stream.WriteFloat((uint)PropertyID.GameScore, _gameScore);
                    _gameScoreShouldWrite = false;
                }
            }
        }
    }
    
    public void Read(ReadStream stream, StreamContext context) {
        // Loop through each property and deserialize
        uint propertyID;
        while (stream.ReadNextPropertyID(out propertyID)) {
            switch (propertyID) {
                case (uint)PropertyID.GameScore: {
                    float previousValue = _gameScore;
                    
                    _gameScore = stream.ReadFloat();
                    _gameScoreShouldWrite = false;
                    
                    if (_gameScore != previousValue)
                        FireGameScoreDidChange(_gameScore);
                    break;
                }
                default:
                    stream.SkipProperty();
                    break;
            }
        }
    }
}
/* ----- End Normal Autogenerated Code ----- */
