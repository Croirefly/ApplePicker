using UnityEngine;
using System.Collections;

public class AppleBad : MonoBehaviour {
	public GameObject appleBadPop;
	public static float bottomY = -15f; //static is a shared variable that changes for all instances

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < bottomY) {
			GameObject appleBadPopInstance = Instantiate (appleBadPop, this.transform.position, this.transform.rotation) as GameObject;
			Destroy ( this.gameObject);
		
		}

	}
}
