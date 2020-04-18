using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyancySounds : MonoBehaviour
{
    //public AudioSource inflatorAudio;
    //public AudioClip bubblesDeflationAudio;
    //public AudioClip bcInflationAudio;

    public buoyancyController buoyancyControllerz;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ////AUDIO FAIL - attempt 1
        //if (buoyancyControllerz.deflationPlaying)
        //{
        //    bcInflationAudio.Stop();
        //    bubblesDeflationAudio.Play();

        //}
        //if (buoyancyControllerz.inflationPlaying)
        //{
        //    bubblesDeflationAudio.Stop();
        //    bcInflationAudio.Play();

        //}
        //else
        //{
        //    bcInflationAudio.Stop();
        //    bubblesDeflationAudio.Stop();
        //}

    }

    //attempt at reusable code for Controller
    //public void PlaySound(bool trigger, bool otherTrigger)
    //{
    //    if (trigger == true)
    //    {
    //        otherTrigger = true;
    //    }
    //    else
    //    {
    //        otherTrigger = false;
    //    }
    //}

}
