﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	public float scoreCount;
	public float highScoreCounter;

	public float pointsPerFrame;

	public bool scoreIncreasing;

	// Use this for initialization
	void Start () {
		scoreCount = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

		scoreText.text = "Score: " + scoreCount;
		scoreCount += pointsPerFrame;
		
	}
}