using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the left and right arrow key values
        float horizontalInput = Input.GetAxis("Horizontal"); //LEFT OR RIGHT

        //changes the rotation of the object the script is attached to
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

    }
}
