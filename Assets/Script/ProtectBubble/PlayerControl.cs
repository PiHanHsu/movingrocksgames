using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public static float HP;
	public static int Score;
	public GameObject AddHP;
	public AudioSource CoinSound;
	public AudioSource AddHPSound;
	public AudioSource ExploSound;
	public GameObject ExploEffect;

	private GameObject exploEffect;
	// Use this for initialization
	void Start () {
		HP = 100f;
		Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.RightArrow))
		{
			gameObject.transform.position += new Vector3(10f,0,0);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			gameObject.transform.position += new Vector3(-10f,0,0);
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			gameObject.transform.position += new Vector3(0,10f,0);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			gameObject.transform.position += new Vector3(0,-10f,0);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {

		if (col.tag == "Coin") {
			CoinSound.Play ();
			Score += 100;
			Destroy (col.gameObject);
			if (Score % 1000 == 0) {
				Vector3 pos = new Vector3 (Random.Range(-750f, 750f), 500f, 0);
				Instantiate (AddHP, pos, transform.rotation);
			}
		}
		if (col.tag == "Missile") {
			ExploSound.Play ();
			Destroy (col.gameObject);
			if (HP > 0) {
				HP -= 10;
				gameObject.transform.localScale += new Vector3 (5f, 5f, 0);
			} else {

				exploEffect = Instantiate (ExploEffect, gameObject.transform.position, ExploEffect.transform.rotation);
				Destroy (exploEffect, 3);
				Destroy (gameObject);
				StartCoroutine (Gameover ());
			}
		}

		if (col.tag == "AddHP") {
			Destroy (col.gameObject);
			if (HP < 100 ) {
				HP += 10;
				gameObject.transform.localScale -= new Vector3 (5f, 5f, 0);
				AddHPSound.Play ();
			}
		}
	}

	IEnumerator Gameover() {

		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
}
