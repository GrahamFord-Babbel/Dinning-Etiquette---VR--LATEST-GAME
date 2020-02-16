using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeMonster : MonoBehaviour
{
    public GameObject telescope;
    public GameObject monster;

    // Start is called before the first frame update
    void Start()
    {
        //monster.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
