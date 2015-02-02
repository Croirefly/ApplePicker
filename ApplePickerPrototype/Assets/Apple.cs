using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	public static float bottomY = -15f; //static is a shared variable that changes for all instances

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < bottomY) {
			Destroy ( this.gameObject);

			//Get a reference to the ApplePicker comp of Main Camera
			ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
			//Call public AppleDestroyed() method of apScript
			apScript.AppleDestroyed();
		
		}

	}
}
