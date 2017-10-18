using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {


	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetweenMin;
	public float distanceBetweenMax;

	public ObjectPooler[] objectPoolers;

	public GameObject[] thePlatforms;





	private float platformWidth;
	private float distanceBetween;
	private int platformSelecctor;
	private float[] platformWidths;


	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;
	


	// Use this for initialization
	void Start () {

		//platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
		platformWidths = new float[objectPoolers.Length];

		for (int i = 0; i < thePlatforms.Length; i++) {
			platformWidths [i] = objectPoolers [i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

	}
	
	// Update is called once per frame
	void Update () {



		if(transform.position.x < generationPoint.position.x) {

			platformSelecctor = Random.Range (0, objectPoolers.Length);

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			heightChange = transform.position.y + Random.Range(-maxHeightChange, maxHeightChange);

			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} else if (heightChange < minHeight) {
				heightChange = minHeight;
			}


			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelecctor]/2) + distanceBetween,
				heightChange, transform.position.z);


			//Instantiate (/*thePlatform*/thePlatforms[platformSelecctor],
				//transform.position, transform.rotation);

			GameObject newPlatform = objectPoolers[platformSelecctor].GetPooledObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);
			//newPlatform.transform. = new Vector3 (newPlatform.transform.localScale.x,
			//	newPlatform.transform.localScale.y * 2, newPlatform.transform.localScale.z);

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelecctor] / 2),
				transform.position.y, transform.position.z);

		}
			
		
	}
}
