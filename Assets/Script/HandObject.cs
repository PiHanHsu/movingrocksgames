using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandObject : MonoBehaviour {

	public string HandType;
	public GameObject AttackEffect;

	private GameObject attackEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {

		if (col.tag == "Heart") {
			//Destroy (col.gameObject);

			if (HandType == "Left") {
				GameControl.winningText = "The winner is Player1";
			}

			if (HandType == "Right") {
				GameControl.winningText = "The winner is Player2";
			}

			GameControl.gameover = true;

			//attackEffect = Instantiate (AttackEffect, col.transform.position, transform.rotation);
		}


		if (col.tag == "Button1") {
			
			Destroy (col.gameObject);
			int r = (int)Random.Range (1, 5);
			GameControl.card1_number = r.ToString ();
		}
		if (col.tag == "Button2") {

			Destroy (col.gameObject);
			int r = (int)Random.Range (1, 5);
			GameControl.card2_number = r.ToString ();
		}
			
	}
}
