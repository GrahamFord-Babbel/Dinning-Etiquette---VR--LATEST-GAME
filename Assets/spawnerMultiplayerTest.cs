using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class spawnerMultiplayerTest : MonoBehaviour
{
    private Realtime _realtime;

    public GameObject ObjectToSpawn2;

    private void Awake()
    {
        // Get the Realtime component on this game object
        _realtime = GetComponent<Realtime>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateObject", Random.Range(0, 4), 5);
    }

    // Update is called once per frame

    public void GenerateObject()
    {
        Instantiate(ObjectToSpawn2, ObjectToSpawn2.transform.position, transform.rotation);
        //ObjectToSpawn.transform.localScale = Vector3.one * Random.Range(objectSizeMin, objectSizeMax);
    }

}

