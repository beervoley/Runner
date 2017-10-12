using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public int currentScore;
	public int highScore;
	private static string highScoreKey = "highScore";
	private static string currentScoreKey = "currentScore";

	public static ScoreManager instance;

	void Awake() {
		if(instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		currentScore = 0;
		PlayerPrefs.SetInt (currentScoreKey, currentScore);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void IncrementScore() {
		currentScore++;
	}

	public void StartScore() {
		InvokeRepeating ("IncrementScore", 0.1f, 0.5f);
	}

	public void StopScore() {
		CancelInvoke ("IncrementScore");
		PlayerPrefs.SetInt (currentScoreKey, currentScore);
		if (PlayerPrefs.HasKey (highScoreKey) && PlayerPrefs.GetInt (highScoreKey) < currentScore) {
			PlayerPrefs.SetInt (highScoreKey, currentScore);
		} else if (!PlayerPrefs.HasKey (highScoreKey)) {
			PlayerPrefs.SetInt (highScoreKey, currentScore);
		}
	}

}
