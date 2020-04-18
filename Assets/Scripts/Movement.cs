using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

//Job Summary - control the Dad player's position using WASD
public class Movement : MonoBehaviour
{
    //allow a designer to alter speed in Inspector
    public float speed = 10;
    private Rigidbody thisRb;

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
        thisRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //clears any forces on the object that don't come from WASD - TODO - create a less frequently called solution
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            thisRb.velocity = new Vector3(0,0,0);
        }

        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            _realtimeView.RequestOwnership(); //TODO - recheck if this is necessary
            _realtimeTransform.RequestOwnership();
        }

        //move player - TODO - consider normalizing values, but the chaos of unnormalized is good so far
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime*speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }

}

