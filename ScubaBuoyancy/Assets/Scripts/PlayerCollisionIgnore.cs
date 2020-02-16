using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionIgnore : MonoBehaviour
{
    public GameObject playerDiver;

    void Start()
    {
        //this is needed
        Physics.IgnoreCollision(playerDiver.GetComponent<Collider>(), GetComponent<Collider>());

    }

}