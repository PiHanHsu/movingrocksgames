using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two_Players : MonoBehaviour {

	public GameObject Left_Missile;
	public GameObject Left_Launcher;
	public GameObject Right_Missile;
	public GameObject Right_Launcher;

	public GameObject HP_Level_1P;
	public GameObject HP_Text_1P;
	public GameObject HP_Level_2P;
	public GameObject HP_Text_2P;
	public static float hp_1p;
	public static float hp_2p;


	public GameObject WinningText;
	public GameObject NewGameText;

	public GameObject Bubble;

	public static bool isPlaying = true;
	public static string winner;

	private GameObject right_Missile;
	private GameObject left_Missile;
	private GameObject bubble;

	private float bubble_time;

	// Use this for initialization
	void Start () {
		ResetGame ();
	}

	// Update is called once per frame
	void Update () {

		bubble_time += Time.deltaTime;

		if (isPlaying) {
			NewGameText.SetActive (false);
			WinningText.SetActive (false);
			if (bubble_time > 10.0f) {
				bubble = Instantiate (Bubble, new Vector3 (0, -550, 0), Bubble.transform.rotation);
				bubble_time = 0f;
			}

			if (bubble != null) {
				bubble.transform.position += new Vector3 (0, 10f, 0);
			}


			if (Input.GetKeyDown (KeyCode.V)) {
				left_Missile = Instantiate (Left_Missile, new Vector3 (Left_Launcher.gameObject.transform.position.x + 100, Left_Launcher.gameObject.transform.position.y, 0), transform.rotation);
			}

			if (Input.GetKeyDown (KeyCode.Slash)) {
				right_Missile = Instantiate (Right_Missile, new Vector3 (Right_Launcher.gameObject.transform.position.x - 100, Right_Launcher.gameObject.transform.position.y, 0), Right_Missile.transform.rotation);
			}


			HP_Text_1P.GetComponent<TextMesh>().text = hp_1p.ToString() +  " / 100";
			HP_Level_1P.transform.localScale = new Vector3 (hp_1p * 3f , 200f, 1);
			HP_Text_2P.GetComponent<TextMesh>().text = hp_2p.ToString()  + " / 100";
			HP_Level_2P.transform.localScale = new Vector3 (hp_2p * 3f, 200f, 1);

			if (hp_1p <= 0 || hp_2p <= 0) {
				isPlaying = false;
			}

		} else {
			NewGameText.SetActive (true);
			if (hp_1p > 0) {
				WinningText.GetComponent<TextMesh> ().text = "The Winner is Mario";
			} else {
				WinningText.GetComponent<TextMesh> ().text = "The Winner is Luigi";
			}
			WinningText.SetActive (true);
		}
			
		if (Input.GetKeyDown (KeyCode.Return)) {
			ResetGame ();
		}
	}

	void ResetGame(){
		isPlaying = true;

		hp_1p = 100f;
		hp_2p = 100f;

	}
}
