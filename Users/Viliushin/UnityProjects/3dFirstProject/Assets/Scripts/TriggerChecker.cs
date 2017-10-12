using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit(Collider col) {

		if (col.gameObject.tag == "Ball") {
			Invoke ("fallDown", 1f);
		}
	}


	void fallDown() {
		GetComponentInParent<Rigidbody> ().useGravity = true;
		GetComponentInParent<Rigidbody> ().isKinematic = false;
		if (transform.parent.gameObject) {
			Destroy (transform.parent.gameObject, 1f);
		}

	}
}
