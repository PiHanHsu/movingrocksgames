using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3 (0, -3f, 0);
	}
	void OnTriggerEnter2D (Collider2D col) {
	}
}
