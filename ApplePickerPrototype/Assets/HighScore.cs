using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {

	static public int score = 1000;
	private Text highScore;

	// Use this for initialization
	void Awake () {
		//if ApplePickerHighScore already exists, read it
		GameObject highScoreX = GameObject.Find ("HighScore");
		highScore = highScoreX.GetComponent<Text>();
		if (PlayerPrefs.HasKey ("ApplePickerHighScore")) {
			score = PlayerPrefs.GetInt ("ApplePickerHighScore");
		}
		//Assign the high score to ApplePickerHighScore
		PlayerPrefs.SetInt ("ApplePickerHighScore", score);
	}
	
	// Update is called once per frame
	void Update () {
		highScore.text = "Best: " + score;
		//Update ApplePickerHighScore in PlayerPrefs if necessary
		if (score > PlayerPrefs.GetInt ("ApplePickerHighScore")) {
			PlayerPrefs.SetInt ("ApplePickerHighScore", score);
		}
	}
}
