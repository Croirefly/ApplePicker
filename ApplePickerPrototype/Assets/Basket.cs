using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Basket : MonoBehaviour {

	private Text scoreCounter;

	public Rigidbody appleTrail;
	private Transform scoreCounterY;
	public GameObject applePop;

	// Use this for initialization
	void Start () {
		GameObject scoreCounterX = GameObject.Find ("ScoreCounter");
		scoreCounter = scoreCounterX.GetComponent<Text>();
		GameObject scoreCounterXX = GameObject.Find ("ScoreCounterPox");
		scoreCounterY = scoreCounterXX.transform;
		scoreCounter.text = "0";
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision coll) {
		GameObject collidedWith = coll.gameObject;
		if(collidedWith.tag == "Apple") {
			//Rigidbody appleTrailInstance = Instantiate ( appleTrail, collidedWith.transform.position, this.transform.rotation ) as Rigidbody;
			//appleTrailInstance.transform.LookAt(scoreCounterY);
			//appleTrailInstance.rigidbody.AddRelativeForce(new Vector3(0,0,5000));

			GameObject applePopInstance = Instantiate ( applePop ) as GameObject;
			applePopInstance.transform.position = collidedWith.transform.position;

			Destroy (collidedWith);

			//parse text of score into int
			int score = int.Parse (scoreCounter.text);
			//add pts for catching
			score += 100;
			//convert score to string
			scoreCounter.text = score.ToString();

			//track high score
			if(score > HighScore.score) {
				HighScore.score = score;
			}
		}
		if(collidedWith.tag == "AppleBad") {
			ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
			apScript.AppleDestroyed();
		}
	}
}
