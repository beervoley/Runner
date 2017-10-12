using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckerForDiamond : MonoBehaviour {


	public GameObject particle;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col) {

		if (col.gameObject.tag == "Ball") {
			Destroy (transform.parent.gameObject);
			GameObject part = Instantiate (particle, transform.position, Quaternion.identity);
			Destroy (part, 1f);
		}
		
	}




}
