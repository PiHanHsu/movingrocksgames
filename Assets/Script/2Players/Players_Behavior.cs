using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players_Behavior : MonoBehaviour {

	public GameObject ProtectBubble;
	public GameObject HP_Level;
	public GameObject HP_Text;


	private float protectingTime;
	private float hp_level= 100f;
	private float whp;

	// Use this for initialization
	void Start () {
		ProtectBubble.SetActive (false);
		whp = HP_Level.transform.localScale.x * 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		protectingTime += Time.deltaTime;
		ProtectBubble.transform.position = transform.position;

		if (protectingTime > 8.0f) {
			ProtectBubble.SetActive (false);
		}
		
	}

	void OnTriggerEnter2D (Collider2D col){
		
		if (Two_Players.isPlaying) {
			if (col.tag == "Bubble") {
				ProtectBubble.SetActive (true);
				protectingTime = 0;
				Destroy (col.gameObject);
			}

			if (col.tag == "Missile") {
				Destroy (col.gameObject);
				hp_level -= 10f;
				HP_Text.GetComponent<TextMesh>().text = hp_level.ToString() + " / 100";
				HP_Level.transform.localScale -= new Vector3 (whp, 0, 0);
				if (hp_level < 1.0 ) {
					Two_Players.isPlaying = false;
				}
			}
		}
	}
}
