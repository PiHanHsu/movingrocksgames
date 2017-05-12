using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players_Behavior : MonoBehaviour {

	public GameObject ProtectBubble;

	private float protectingTime;

	// Use this for initialization
	void Start () {
		ProtectBubble.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		protectingTime += Time.deltaTime;
		ProtectBubble.transform.position = transform.position;

		if (protectingTime > 8.0f) {
			ProtectBubble.SetActive (false);

		}
		
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Bubble") {
			ProtectBubble.SetActive (true);
			protectingTime = 0;
			Destroy (col.gameObject);
		}

		if (col.tag == "Missile") {
			Destroy (col.gameObject);
			print ("hit by Missile");
		}
	}
}
