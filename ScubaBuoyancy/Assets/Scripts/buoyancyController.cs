using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buoyancyController : MonoBehaviour
{
    //sources for playing audio when inflating and deflating
    public AudioSource inflatorAudio;
    public AudioClip bubblesDeflationAudio;
    public AudioClip bcInflationAudio;


    //how much the buoyancy increases or decreases
    public float thrust;
    //public delegate float thrustMethodResult(float x);
    //public TestDelegate thrustMethodResult;

    //player essentials
    public OVRPlayerController player;
    public Transform playerTransform;

    //limit that keeps player from accelerating too fast
    public float gravityLimit;
    bool stopThrust;

    //AUDIO FAIL - attempt 1, attempt 2
    ////audio conditions
    //public bool deflationPlaying;
   //public bool inflationPlaying;

    public BuoyancySounds buoyancySounds;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            //attempt audio2
            //buoyancySounds.PlaySound(OVRInput.Get(OVRInput.Button.PrimaryHandTrigger), inflationPlaying);

            //AUDIO FAIL - attempt 1
            ////play sound condition
            //if (!inflationPlaying)
            //{
            //    inflationPlaying = true;
            //}
            

            //go up - audio semisuccess
            playerDirection(thrust);
            inflatorAudio.PlayOneShot(bcInflationAudio);

            //attempt 2- to decrease acceleration, passing one method insde another
            //thrustMethodResult(playerDirection(-thrust));

        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            //attempt audio2
            //buoyancySounds.PlaySound(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger), deflationPlaying);

            //AUDIO FAIL - attempt 1
            ////play sound condition
            //if (!deflationPlaying)
            //{
            //    deflationPlaying = true;
            //}

            //go down- audio semisuccess
            playerDirection(-thrust);
            inflatorAudio.PlayOneShot(bubblesDeflationAudio);
        }

        //MASSIVE FAIL - attempt1 to decrease acceleration on release - NEED SO THAT YOU CAN have the initial thrust be higher
        //else
        //{
        //    if((player.GravityModifier > 0.5f || player.GravityModifier < -0.5f))
        //    {
        //        stopThrust = false;
        //    }
        //    //decrease modifier until 0 (to make it so that it player stabilizes once releasing...is this accurate? felt like that when diving)
        //    if (!stopThrust)
        //    {
        //        if (player.GravityModifier > 0.5f)
        //        {
        //            playerDirection(-thrust);
        //        }
        //        if (player.GravityModifier < -0.5f)
        //        {
        //            playerDirection(thrust);
        //        }
        //        else if (player.GravityModifier < 0.5f || player.GravityModifier > -0.5f)
        //        {
        //            stopThrust = true;
        //        }
        //    }

        //}


        //AUDIO FAIL - attempt 1
        //else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        //{
        //    inflationPlaying = false;
        //    deflationPlaying = false;
        //}
    }

    void playerDirection(float positiveNegative)
    {
        //attempt 3 - WORKS!
        if(player.GravityModifier < gravityLimit && player.GravityModifier > -gravityLimit)
        {
            //increase or decrease the acceleration of the player via gravity depending on if hit inflator or deflator
            player.GravityModifier = player.GravityModifier + positiveNegative;
            //use to decelerate?
            //positiveNegative = positiveNegative / 2;

            //if limit exceeded, reset to 0 acceleration (realistic?)
            if (player.GravityModifier > gravityLimit || player.GravityModifier < -gravityLimit)
            {
                player.GravityModifier = 0;
            }
        }

        //attempt 2
        //playerTransform.Translate(0, positiveNegative * thrust, 0);
        //attempt 1
        //playerRb.AddForce(positiveNegative * thrust, 0, 0, ForceMode.Impulse);
    }
}
