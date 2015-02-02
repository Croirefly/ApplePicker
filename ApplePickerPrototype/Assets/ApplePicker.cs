using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApplePicker : MonoBehaviour {

	public GameObject basketPrefab;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;
	public List<GameObject> basketList;
	public GameObject applePop;
	public GameObject appleBadPop;
	public Transform basketHolder;

	// Use this for initialization
	void Start () {
		basketList = new List<GameObject>();
		for (int i=0; i<numBaskets; i++) {
			GameObject tBasketGO = Instantiate (basketPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGO.transform.position = pos;
			
			tBasketGO.transform.parent = basketHolder;
			basketList.Add(tBasketGO);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AppleDestroyed () { //public allows other scripts to access
		//Destroy all of the falling Apples
		GameObject [] tAppleArray = GameObject.FindGameObjectsWithTag ("Apple"); //returns array of existing apples
		foreach ( GameObject tGO in tAppleArray ) {
			GameObject applePopInstance = Instantiate ( applePop ) as GameObject;
			applePopInstance.transform.position = tGO.transform.position;

			Destroy  (tGO);
		}
		GameObject [] tAppleBadArray = GameObject.FindGameObjectsWithTag ("AppleBad"); //returns array of existing apples
		foreach ( GameObject tGO in tAppleBadArray ) {
			GameObject appleBadPopInstance = Instantiate ( appleBadPop ) as GameObject;
			appleBadPopInstance.transform.position = tGO.transform.position;
			Destroy  (tGO);
		}
		//Destroy one of the baskets
		//get the index of the last Basket in basketList
		int basketIndex = basketList.Count-1;
		//Get a refernece to that Basket GameObject
		GameObject tBasketGO = basketList [basketIndex];
		//Remove the basket from the list and destroy the GameObject
		basketList.RemoveAt(basketIndex);
		Destroy (tBasketGO);

		//Restart game which doesnt affect HighScore.Score
		if(basketList.Count == 0) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
