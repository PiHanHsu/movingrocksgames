using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	
	private float x;
	private float y;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		x = gameObject.transform.position.x;
		y = gameObject.transform.position.y;
		
		if (x <= -800 && y < 400 ) {
			gameObject.transform.position = new Vector3 (-800f, y, 0); 
			gameObject.transform.position += new Vector3 (0, 5f, 0);
		}	

		if (x >= 800 && y > -400) {
			
			gameObject.transform.position = new Vector3 (800, y, 0); 
			gameObject.transform.position += new Vector3 (0, -5f, 0);
		}

		if (y >= 400 && x < 800) {
			gameObject.transform.position = new Vector3 (x, 400f, 0); 
			gameObject.transform.position += new Vector3 (5f, 0, 0);
		}

		if (y <= -400 && x > -800) {
			gameObject.transform.position = new Vector3 (x, -400f, 0); 
			gameObject.transform.position += new Vector3 (-5f, 0, 0);
		}

	}
}
