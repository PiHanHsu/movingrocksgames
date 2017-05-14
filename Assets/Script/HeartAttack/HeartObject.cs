using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartObject : MonoBehaviour {

	public GameObject AttackEffect;

	private GameObject attackEffect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {

		if (col.tag == "LeftHand") {
			
				//attackEffect = Instantiate (AttackEffect, transform.position, transform.rotation);
				//GameControl.isPlaying = false;
				//GameControl.WinningText.GetComponent<TextMesh> ().text = "";
			    //StartCoroutine (GameControl.Gameover ("The winner is Player1"));
			    Destroy (this.gameObject);
			    Destroy (col.gameObject);

		}
		if (col.tag == "RightHand") {
			//attackEffect = Instantiate (AttackEffect, transform.position, transform.rotation);
			//GameControl.isPlaying = false;
			//GameControl.WinningText.GetComponent<TextMesh> ().text = "";
			//StartCoroutine (GameControl.Gameover ("The winner is Player1"));
			Destroy (this.gameObject);
			Destroy (col.gameObject);

		}
    }
}
