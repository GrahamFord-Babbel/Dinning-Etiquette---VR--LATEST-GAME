using UnityEngine;
using Normal.Realtime;

namespace Normal.Realtime.Examples
{
    public class CubePlayerManager : MonoBehaviour
    {
        private Realtime _realtime;
        public Transform playerPosition;

        private void Awake()
        {
            // Get the Realtime component on this game object
            _realtime = GetComponent<Realtime>();

            // Notify us when Realtime successfully connects to the room
            _realtime.didConnectToRoom += DidConnectToRoom;
        }

        private void DidConnectToRoom(Realtime realtime)
        {
            //Instantiate the CubePlayer for this client once we've successfully connected to the room
            Realtime.Instantiate("CubePlayer",                 // Prefab name
                                position: playerPosition.position + new Vector3(1, 0, 0),          // Start 1 meter in the air
                                rotation: Quaternion.identity, // No rotation
                           ownedByClient: false,   // Make sure the RealtimeView on this prefab is owned by this client
               preventOwnershipTakeover: true,                // Prevent other clients from calling RequestOwnership() on the root RealtimeView.
                            useInstance: realtime);           // Use the instance of Realtime that fired the didConnectToRoom event.
        }
    }
}


// Start is called before the first frame update
//void Start()
//{

//    //Realtime.Instantiate("BottleMultTest", playerPosition.position + new Vector3(1,0,0), playerPosition.rotation);

//    //this is causing the duplicate UUID issue
//    //InvokeRepeating("GenerateObject", Random.Range(0, 4), 5);
//}

//// Update is called once per frame

//public void GenerateObject()
//{
//    //Instantiate(ObjectToSpawn2, ObjectToSpawn2.transform.position, transform.rotation);
//    //ObjectToSpawn.transform.localScale = Vector3.one * Random.Range(objectSizeMin, objectSizeMax);
//}