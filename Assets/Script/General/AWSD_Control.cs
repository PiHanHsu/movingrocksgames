﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWSD_Control : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.D))
		{
			gameObject.transform.position += new Vector3(10f,0,0);
		}
		if (Input.GetKey(KeyCode.A))
		{
			gameObject.transform.position += new Vector3(-10f,0,0);
		}
		if (Input.GetKey(KeyCode.W))
		{
			gameObject.transform.position += new Vector3(0,10f,0);
		}

		if (Input.GetKey(KeyCode.S))
		{
			gameObject.transform.position += new Vector3(0,-10f,0);
		}
	}
}
