using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sushi : MonoBehaviour {

	private float x;
	private float y;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		x = gameObject.transform.position.x;
		y = gameObject.transform.position.y;

		if (x <= -900 && y < 490 ) {
			gameObject.transform.position = new Vector3 (-900f, y, 0); 
			gameObject.transform.position += new Vector3 (0, 1f, 0);
		}	

		if (x >= 900 && y > -490) {

			gameObject.transform.position = new Vector3 (900, y, 0); 
			gameObject.transform.position += new Vector3 (0, -1f, 0);
		}

		if (y >= 490 && x < 900) {
			gameObject.transform.position = new Vector3 (x, 490f, 0); 
			gameObject.transform.position += new Vector3 (1f, 0, 0);
		}

		if (y <= -490 && x > -900) {
			gameObject.transform.position = new Vector3 (x, -490f, 0); 
			gameObject.transform.position += new Vector3 (-1f, 0, 0);
		}
	}
}
