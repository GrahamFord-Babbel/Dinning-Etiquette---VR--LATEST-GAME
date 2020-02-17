using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHasHit : MonoBehaviour
{
    //get scoreKeeper
    public ScoreKeeper scoreKeeper; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //stores the object using that objects collider
        GameObject obj = other.gameObject;

        //checks to see if the object that collided with Dad originated from the Spawner
        if (obj.tag == "BabyObject")
        {
            //for when object hits dad
            if(this.gameObject.name == "DadPlayer")
            {
                //Increment Dad Score - get IncrementScore by __ from ScoreKeeper - specific to the Gameobjects Points (Negative or Positive)
                scoreKeeper.DadScored(1);

                //checks to see if of type increase is working
                Debug.Log(this.gameObject.name + "Score Increase");
            }
            //for when object hits ground
            else
            {
                //Increment Dad Score - get IncrementScore by __ from ScoreKeeper - specific to the Gameobjects Points (Negative or Positive)
                scoreKeeper.BabyScored(1);

                //checks to see if of type increase is working
                Debug.Log(this.gameObject.name + "Score Increase");
            }

        }

        //use switch for the score keeping for how it effects the score depending on the object that hit Dad?
        //switch (switch_on)
        //{
        //    default:
        //}


        //OF TYPE JUNK
        ////checks to see if the object that collided with Dad originated from the Spawner
        //if (obj.GetType() == typeof(SpawnManagerScriptableObject))
        //{
        //    //Increment Dad Score - get IncrementScore by __ from ScoreKeeper - specific to the Gameobjects Points (Negative or Positive)

        //    //checks to see if of type increase is working
        //    Debug.Log(this.gameObject.name + "Score Increase - via Type");
        //}
    }

}
