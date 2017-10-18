using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

	public GameObject pooledObject;

	public int pooledAmount;

	private List<GameObject> pooledObjects;



	// Use this for initialization
	void Start () {
		pooledObjects = new List<GameObject> ();

		for (int i = 0; i < pooledAmount; i++) {

			GameObject obj = (GameObject)Instantiate (pooledObject);
			obj.SetActive (false);
			pooledObjects.Add (obj);
		}
			
		
	}

	public GameObject GetPooledObject() {
		
		foreach (GameObject obj in pooledObjects) {
			if (!obj.activeInHierarchy) {
				return obj;
			}
		}

		GameObject newObj = (GameObject)Instantiate(pooledObject);
		newObj.SetActive(false);
		pooledObjects.Add(newObj);
		return newObj;
	}
}
