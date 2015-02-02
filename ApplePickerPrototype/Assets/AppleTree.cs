using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	public GameObject applePrefab;
	public GameObject appleBadPrefab;
	public float speedX = 1f;
	public float speedZ = 10f;
	public float leftAndRightEdge = 10f; //where apple tree reverses direction
	public float topAndBotEdge = 6f;
	public float chanceToChangeDirections = 0.1f;
	public float secondsBetweenAppleDrops = 1f;
	public float appleBadChance = 0.5f;


	// Use this for initialization
	void Start () {
		//Dropping apples every second
		InvokeRepeating ("DropApple", 2f, secondsBetweenAppleDrops);
	}
	
	// Update is called once per frame
	void Update () {
		//basic movement
		Vector3 pos = transform.position;
		pos.x += speedX * Time.deltaTime;
		//z pos
		pos.z += speedZ * Time.deltaTime;

		transform.position = pos;


		if (pos.x < -leftAndRightEdge) {
			speedX = Mathf.Abs (speedX); // move right
		}else if (pos.x > leftAndRightEdge) {
			speedX = -Mathf.Abs (speedX); //move left
		}
		if (pos.z < -topAndBotEdge) {
			speedZ = Mathf.Abs (speedZ); // move right
		}else if (pos.z > topAndBotEdge) {
			speedZ = -Mathf.Abs (speedZ); //move left
		}
	}
	void FixedUpdate () {
		if (Random.value < chanceToChangeDirections ) {
			speedX *= -1; //change direction
		}
		if (Random.value < chanceToChangeDirections ) {
			speedZ *= -1; //change direction
		}
	}
	void DropApple() {
		if (Random.value > appleBadChance ) {
			GameObject apple = Instantiate ( applePrefab ) as GameObject;
			apple.transform.position = transform.position;
		} else {
			GameObject appleBad = Instantiate ( appleBadPrefab ) as GameObject;
			appleBad.transform.position = transform.position;
		}
	}
}
