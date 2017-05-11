using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMissile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
		gameObject.transform.position += new Vector3 (-5f, 0, 0);
	}
		
}
