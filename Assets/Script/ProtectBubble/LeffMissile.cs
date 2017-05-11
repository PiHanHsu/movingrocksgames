using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeffMissile : MonoBehaviour {

	public GameObject Explosion;
	public AudioSource Explo;
	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
		gameObject.transform.position += new Vector3 (5f, 0, 0);
	}

	void OnTriggerEnter2D (Collider2D col) {

		if (col.tag == "Player") {
			//Destroy (gameObject);
			//Instantiate (Explosion, gameObject.transform.position, transform.rotation);	
			Explo.Play ();
		}
	}
}
