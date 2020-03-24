using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Movement : MonoBehaviour
{
    //public makes it visible
    public float speed;

    private RealtimeView _realtimeView;
    private RealtimeTransform _realtimeTransform;

    private void Awake()
    {
        _realtimeView = GetComponent<RealtimeView>();
        _realtimeTransform = GetComponent<RealtimeTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (speed == 0)
        {
            speed = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            _realtimeView.RequestOwnership();
            _realtimeTransform.RequestOwnership();
        }

        transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*speed,0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }

}

