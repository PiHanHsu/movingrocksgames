using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandObject : MonoBehaviour {

	public string Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {

		if (col.tag == "Heart") {
			//Destroy (col.gameObject);

			print (Player);

			if (Player == "P1ayer1") {
				GameControl.winningText = "The winner is Player1";
			}

			if (Player == "P1ayer2") {
				GameControl.winningText = "The winner is Player2";
			}

			GameControl.gameover = true;


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
