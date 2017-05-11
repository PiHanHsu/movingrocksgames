using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {


	public AudioSource Explo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AnimationStart() {
		Explo.Play ();
	}

	void AnimationEnd() {
		Destroy (gameObject);
	}



}
