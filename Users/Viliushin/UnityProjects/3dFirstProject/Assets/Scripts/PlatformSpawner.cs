﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {


	public GameObject platform;
	public GameObject temp;

	public GameObject diamondX;
	public GameObject diamondZ;
	Vector3 lastPos;
	float size;
	bool gameOver = false;



	// Use this for initialization
	void Start () {
		lastPos = platform.transform.position;
		size = platform.transform.localScale.x;
		for (int i = 0; i < 5; i++) {
			SpawnPlatforms ();
		}
	}

	public void StartSpawningPlatforms() {
		InvokeRepeating ("SpawnPlatforms", 1f, 0.2f);
	}

	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameOver) {
			CancelInvoke ("SpawnPlatforms");
		}
	}


	void SpawnPlatforms() {
		if (GameManager.instance.gameOver) {
			return;
		}
		if (Random.Range (0, 2) == 1) {
			SpawnX ();

		} else {
			SpawnZ ();
		}
	}


	void SpawnX() {

		Vector3 pos = lastPos;
		pos.x += size;
		lastPos = pos;

		Instantiate (platform, pos, Quaternion.identity);


		if (Random.Range (0, 5) < 1) {
			Vector3 diamondPoisiton = new Vector3 (pos.x, pos.y + diamondX.transform.lossyScale.y + 0.2f, pos.z);
			Instantiate (diamondX, diamondPoisiton, diamondX.transform.rotation);
				
		}


	}

	void SpawnZ() {
				Vector3 pos = lastPos;
		pos.z += size;
		lastPos = pos;
		Instantiate (platform, pos, Quaternion.identity);
		if (Random.Range (0, 5) < 1) {
			Vector3 diamondPoisiton = new Vector3 (pos.x, pos.y + diamondZ.transform.lossyScale.y + 0.2f, pos.z);
			Instantiate (diamondZ, diamondPoisiton, diamondZ.transform.rotation);
		}
	}
}
