using UnityEngine;
using Normal.Realtime;

namespace Normal.Realtime.Examples {
    public class CubePlayer : MonoBehaviour {

        private RealtimeView      _realtimeView;
        private RealtimeTransform _realtimeTransform;

        private void Awake() {
            _realtimeView      = GetComponent<RealtimeView>();
           _realtimeTransform = GetComponent<RealtimeTransform>();
        }

        private void Start()
        {
            //_realtimeTransform.RequestOwnership();
            //_realtimeTransform.RequestOwnership();
        }

        private void Update() {

            //_realtimeTransform.RequestOwnership();

            if (gameObject.GetComponent<OVRGrabbable>().isGrabbed)
            {
                _realtimeTransform.RequestOwnership();
            }

            //if (GetComponent<Rigidbody>().isKinematic)
            //{
            //    // If this CubePlayer prefab is not owned by this client, bail.
            //    if (!_realtimeView.isOwnedLocally)
            //        return;

            //    // Make sure we own the transform so that RealtimeTransform knows to use this client's transform to synchronize remote clients.
            //    _realtimeTransform.RequestOwnership();
            //}

            ////move the cube for DinEt Dad
            //transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    Destroy(other.gameObject);
        //    print("destroyed other square");
        //}

        //public void GrabRequestOwnership()
        //{
        //    // Make sure we own the transform so that RealtimeTransform knows to use this client's transform to synchronize remote clients.
        //    realtimeTransform.RequestOwnership();
        //}
    }
}
