using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameFunction : MonoBehaviour {

	public GameObject Left_Missile;
	public GameObject Right_Missile;
	public GameObject CoinObject;
	public GUISkin PlayingSkin;
	public AudioSource BackgroundSound;
	public GameObject GameoverSound;

	public Texture GUI_hp;
	public static float GameTime;

	private bool isPlaying;
	private float millileTime1 = 4f;
	private float millileTime2 = 0f;
	private float coinTime = 0f;
	private float addHPTime = 0f;
	private float addLevelTime;
	private float launchMisslePeriod = 5f;

	private GameObject left_Missile;
	private GameObject right_Missile;
	private GameObject coinObject;


	// Use this for initialization
	void Start () {
		BackgroundSound.Play ();
		GameTime = Time.time;
		isPlaying = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey("escape") ){
			Application.Quit();
		}

		if (isPlaying) {
			millileTime1 += Time.deltaTime;
			millileTime2 += Time.deltaTime;
			coinTime += Time.deltaTime;
			addLevelTime += Time.deltaTime;


			if (addLevelTime > 30f) {
				launchMisslePeriod -= 1.0f;
				addLevelTime = 0f;
			}

			if (coinTime > 1f) {
				Vector3 pos = new Vector3 (Random.Range(-900f, 900f), 500f, 0);
				coinObject =  Instantiate (CoinObject, pos, transform.rotation);
				Destroy (coinObject, 7);
				coinTime = 0f;
			}

			if (millileTime1 > launchMisslePeriod) {
				Vector3 pos = new Vector3 (-900f, Random.Range(-500f, 500f), 0);
				left_Missile = Instantiate (Left_Missile, pos, transform.rotation);
				Destroy (left_Missile, 7);
				millileTime1 = 0f;
			}

			if (millileTime2 > (launchMisslePeriod+1.0f)) {
				Vector3 pos = new Vector3 (950f, Random.Range(-500f, 500f), 0);
				right_Missile = Instantiate (Right_Missile, pos, Quaternion.Euler(0, 0, 180));
				Destroy (right_Missile, 7);
				millileTime2 = 1.0f;
			}

		}

	}

	void OnGUI() {

		GUI.skin = PlayingSkin;

		//float whp = Mathf.Clamp (PlayerControl.HP, 0, 100) ;
		float whp = (Screen.width * 0.1f) * PlayerControl.HP / 100f;
		float x = Screen.width * 0.05f;
		float y = Screen.height * 0.05f;


		float scoreLabelWidth = Screen.width * 0.15f;
		float scoreLabelHeight = Screen.height * 0.05f;
		float scoreLabelX = Screen.width - scoreLabelWidth * 1.1f;

		if (PlayerControl.HP > 0) {
			GUI.DrawTexture (new Rect (x, y, whp, 50), GUI_hp);
			GUI.Label (new Rect (x + whp + 10, y, scoreLabelWidth, 50), PlayerControl.HP.ToString() + " / 100");
			GUI.Label (new Rect (scoreLabelX, y, scoreLabelWidth, scoreLabelHeight), "Score:  " + PlayerControl.Score);
			//GUI.Label (new Rect (100, 40, 100, 20), "Time: " + GameTime);
		} else {
			GameOver ();
		}



	}

	void GameOver() {
		isPlaying = false;
		//Instantiate (GameoverSound, transform.position, transform.rotation);
		BackgroundSound.Stop ();
		StartCoroutine (GoToGameover ());
	}

	IEnumerator GoToGameover() {
		
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene ("Gameover");
	}
}

