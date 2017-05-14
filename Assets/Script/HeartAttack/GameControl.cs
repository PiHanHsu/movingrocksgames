using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public GameObject Card1;
	public GameObject Card2;

	public GameObject LeftHand;
	public GameObject RightHand;

	public GameObject Card1_Number;
	public GameObject Card2_Number;
	public GameObject WinningText;
	public GameObject NewGameText;

	public GameObject Diamond;
	public GameObject AttackEffect;
	public GameObject Button1;
	public GameObject Button2;

	static public string card1_number;
	static public string card2_number;
	static public bool isPlaying;
	static public bool gameover;
	static public string winningText;

	private GameObject button1;
	private GameObject button2;

	private GameObject diamond;
	private GameObject attackEffect;


	// Use this for initialization
	void Start () {
		isPlaying = false;
		LeftHand.SetActive (false);
		RightHand.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		WinningText.SetActive (!isPlaying);
		if (isPlaying) {
			
			Card1_Number.GetComponent<TextMesh> ().text = card1_number;
			Card2_Number.GetComponent<TextMesh> ().text = card2_number;

			if (button1 == null && button2 == null) {
				float x = Random.Range (600, 800);
				float y = Random.Range (-450, 450);
				button1 = Instantiate (Button1, new Vector3 (-x, y, 0f), transform.rotation);
				button2 = Instantiate (Button2, new Vector3 (x, y, 0f), transform.rotation);

			}

			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				Destroy (button1);
				int r = (int)Random.Range (1, 5);
				card1_number = r.ToString ();
			}

			if (Input.GetKeyDown (KeyCode.RightShift)) {
				Destroy (button2);
				int r = (int)Random.Range (1, 5);
				card2_number = r.ToString ();
			}


			if (Card1_Number.GetComponent<TextMesh> ().text == Card2_Number.GetComponent<TextMesh> ().text && Card1_Number.GetComponent<TextMesh> ().text != "0") {

				//Card1.SetActive (false);
				//Card2.SetActive (false);
				Destroy (button1);
				Destroy (button2);
				if (diamond == null) {
					diamond = Instantiate (Diamond, Diamond.transform.position, Diamond.transform.rotation);
				}

			}

			if (Input.GetKeyDown (KeyCode.LeftControl)) {
				if (diamond != null) {
					
					attackEffect = Instantiate (AttackEffect, diamond.transform.position, transform.rotation);
					isPlaying = false;
					StartCoroutine (Gameover ("The winner is Player1"));
					WinningText.GetComponent<TextMesh> ().text = "";
					Destroy (diamond);

				}
			}

			if (Input.GetKeyDown (KeyCode.RightControl)) {
				if (diamond != null) {
					
					attackEffect = Instantiate (AttackEffect, diamond.transform.position, transform.rotation);
					isPlaying = false;
					StartCoroutine (Gameover ("The winner is Player2"));
					WinningText.GetComponent<TextMesh> ().text = "";
					Destroy (diamond);
				}
			}

			if (gameover) {
				if (diamond != null) {
					attackEffect = Instantiate (AttackEffect, diamond.transform.position, transform.rotation);
					isPlaying = false;
					StartCoroutine (Gameover (winningText));
					WinningText.GetComponent<TextMesh> ().text = "";
					Destroy (diamond);
					LeftHand.SetActive (false);
					RightHand.SetActive (false);

				}
			}
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			ResetGame ();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

		if (Input.GetKeyDown (KeyCode.F10)) {
			if (LeftHand.activeSelf) {
				LeftHand.SetActive (false);
				RightHand.SetActive (false);
			} else {
				LeftHand.SetActive (true);
				RightHand.SetActive (true);
			}

		}
	}



	void ResetGame(){
		isPlaying = true;
		gameover = false;
		Card1.SetActive (true);
		Card2.SetActive (true);
		card1_number = "0";
		card2_number = "0";
		NewGameText.SetActive (false);
		/*
		LeftHand.SetActive (true);
		LeftHand.gameObject.transform.position = new Vector3 (-100f, 200f, 0);
		RightHand.SetActive (true);
		RightHand.gameObject.transform.position = new Vector3 (100f, 200f, 0);
        */

	}

	public IEnumerator Gameover(string text) {
		yield return new WaitForSeconds (2);
		Card1.SetActive (false);
		Card2.SetActive (false);

		WinningText.GetComponent<TextMesh> ().text = text;
		NewGameText.SetActive (true);

	}

}
