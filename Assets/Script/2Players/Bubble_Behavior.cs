using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_Behavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Missile") {
			Destroy (col.gameObject);
			print ("protect by bubble");
		}
	}
}
