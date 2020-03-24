using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class requestOwner : MonoBehaviour
{
    private RealtimeView _realtimeView;
    public RealtimeTransform _realtimeTransform;

    private void Awake()
    {
        _realtimeView = GetComponent<RealtimeView>();
        _realtimeTransform = GetComponent<RealtimeTransform>();

        //_realtimeTransform.RequestOwnership();
    }

    private void Start()
    {
        //_realtimeTransform.RequestOwnership();
    }

    void Update()
    {
        //if (!_realtimeView.isOwnedLocally)
        //    return;

        // Make sure we own the transform so that RealtimeTransform knows to use this client's transform to synchronize remote clients.
        //_realtimeTransform.RequestOwnership();
    }
}
