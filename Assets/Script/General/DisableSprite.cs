using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSprite : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F3)) {

			if(gameObject.GetComponent<SpriteRenderer>() != null)
			{
				if (gameObject.GetComponent<SpriteRenderer> ().enabled) {
					gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				} else {
					gameObject.GetComponent<SpriteRenderer> ().enabled = true;
				}
			}

		}
	}
}
