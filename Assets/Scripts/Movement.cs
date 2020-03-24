using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public makes it visible
    public float speed;

    private bool TestEnvironment;

    // Start is called before the first frame update
    void Start()
    {
        if (TestEnvironment)
        {
            speed = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*speed,0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }

}

