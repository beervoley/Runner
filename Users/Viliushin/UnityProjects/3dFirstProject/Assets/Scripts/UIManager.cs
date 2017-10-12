using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {

	public static UIManager instance;


	public GameObject zigzagPanel;
	public GameObject gameOverPanel;
	public GameObject taptext;
	public Text score;
	public Text highScoreUnderZigZag;
	public Text highScoreInHighScorePanel;
	private static string highScoreKey = "highScore";
	private static string currentScoreKey = "currentScore";



	void Awake() {
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey (highScoreKey)) {
			highScoreUnderZigZag.text = "High Score: " + PlayerPrefs.GetInt (highScoreKey);
		}
	
	}



	public void GameStart() {
		//if (PlayerPrefs.HasKey (highScoreKey)) {
		//	highScoreUnderZigZag.text = PlayerPrefs.GetInt (highScoreKey) + "";
		//}
		taptext.SetActive (false);
		zigzagPanel.GetComponent<Animator> ().Play ("panelUp");
	}

	public void GameOver() {
		if (PlayerPrefs.HasKey (currentScoreKey)) {
			score.text = PlayerPrefs.GetInt (currentScoreKey) + "";
		}
		if (PlayerPrefs.HasKey (highScoreKey)) {
			highScoreInHighScorePanel.text = PlayerPrefs.GetInt (highScoreKey) + "";
		}
		gameOverPanel.SetActive (true);
	}


	public void Reset() {
		SceneManager.LoadScene ("level1");

	}

	

	
	// Update is called once per frame
	void Update () {
		
	}
}
