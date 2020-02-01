using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayHandBehavior : MonoBehaviour {

	private enum hand { right, left };
	private GameObject hoverObject = null;
	private GameObject grabObject = null;

	private OVRInput.Controller thisController;

	[SerializeField]
	private hand handSide;

	public float throwForce = 20;

	// Use this for initialization
	void Start () {

		thisController = (handSide == hand.right ? OVRInput.Controller.RTouch : OVRInput.Controller.LTouch);

	}
	
	// Update is called once per frame
	void Update () {


		if (OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger, thisController) > 0.0) {
			if (hoverObject != null && grabObject == null) {

				grabObject = hoverObject;
				//grabObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				//grabObject.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
				grabObject.GetComponent<Rigidbody>().isKinematic = true;
								 							
			}

		} 
		else {
		
			if (grabObject != null) {
				grabObject.GetComponent<Rigidbody>().isKinematic = false;
				grabObject.GetComponent<Rigidbody> ().AddForce (OVRInput.GetLocalControllerVelocity(thisController) * throwForce);
				grabObject.GetComponent<Rigidbody> ().AddTorque (OVRInput.GetLocalControllerAngularVelocity(thisController) * throwForce);
				grabObject.transform.parent = null;
				grabObject = null;
			}	
		}

		if (grabObject != null) {
			grabObject.transform.parent = transform;
		}
	}
		
	void OnTriggerEnter(Collider other) {
	
		if (other.tag == "Grabbable") {

			hoverObject = other.gameObject;

		}
	
	}

	void OnTriggerExit(Collider other) {

		if (hoverObject != null && other.gameObject == hoverObject) {

			hoverObject = null;

		}

	}
}


