using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Texture Background;
	public GUISkin GameGUISkin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {

		GUI.skin = GameGUISkin;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), Background);

		float width = Screen.width * 0.5f;
		float height = Screen.height * 0.5f;
		float x = width * 0.5f;
		float y = height * 0.3f;
		GUI.Label (new Rect (x, y, width, height), "Your Score: " + PlayerControl.Score);

		float buttonWidth = width * 0.3f;
		float buttonHeight = height * 0.2f;
		float gap = width * 0.05f;
		if (GUI.Button (new Rect (x , y + height, buttonWidth, buttonHeight), "Main Menu")) {
			SceneManager.LoadScene ("main");
		}

		if (GUI.Button (new Rect (x + buttonWidth + gap, y + height, buttonWidth, buttonHeight), "Play Again")) {
			SceneManager.LoadScene ("ProtectBubble");
		}

		if (GUI.Button (new Rect (x + (buttonWidth + gap) *2 , y + height, buttonWidth, buttonHeight), "Quit")) {
			Application.Quit ();
		}

	}
}
