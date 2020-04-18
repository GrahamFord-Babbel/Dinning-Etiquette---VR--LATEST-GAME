using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Job Summary - fun visual that made Dad appear to be a monster if baby looking through telescope (removed for simplicity)
public class SeeMonster : MonoBehaviour
{
    public GameObject telescope;
    public GameObject monster;

    // Start is called before the first frame update
    void Start()
    {
        //monster.gameObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == telescope)
        {
            monster.gameObject.SetActive(true);
            print("collision with telescope to head");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == telescope)
        {
            monster.gameObject.SetActive(false);
        }
    }
}
