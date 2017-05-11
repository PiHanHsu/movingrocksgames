using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	public GameObject Explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3 (0.05f, 0, 0);
	}

	void OnTriggerEnter2D (Collider2D col) {
	   
		Destroy (this.gameObject);
		Instantiate (Explosion, col.transform.position, transform.rotation);
	
	}

}
