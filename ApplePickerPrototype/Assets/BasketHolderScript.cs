using UnityEngine;
using System.Collections;

public class BasketHolderScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Get the current screen position fo the mouse from Input
		Vector3 mousePos2D = Input.mousePosition;
		
		//Cam z pos sets how far to push the mouse into 3D
		mousePos2D.z = -Camera.main.transform.position.z;
		
		//convert the point from 2d screen space into 3d game world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint ( mousePos2D ); 
		
		Vector3 pos = this.transform.position; //move x pos of basket to x pos of mouse
		pos.x = mousePos3D.x;
		if( mousePos3D.x <= -5) {//if mouse is below fence
			pos.x = mousePos3D.x + 15;
		}else if (mousePos3D.x >= -5) { //if mouse is above fence
			pos.x = 10;
		}
		if(mousePos3D.x <= -11){ //if mouse is below ground
			pos.x = 4;
		}
		pos.z = mousePos3D.z;
		/*if( mousePos3D.y <= -5) {//if mouse is below fence
			pos.y = mousePos3D.y + 15;
		}else if (mousePos3D.y >= -5) { //if mouse is above fence
			pos.y = 10;
		}
		if(mousePos3D.y <= -11){ //if mouse is below ground
			pos.y = 4;
		}*/
		pos.y = 5;
		this.transform.position = pos;
	}
}
