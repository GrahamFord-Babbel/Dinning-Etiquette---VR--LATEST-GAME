using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    public float forwardSpeed;
    private Rigidbody playerRb;

    public GameObject focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        //playerRb.AddForce(Vector3.forward * forwardSpeed * forwardInput);
        playerRb.AddForce(focalPoint.transform.forward * forwardSpeed * forwardInput);
    }
}
