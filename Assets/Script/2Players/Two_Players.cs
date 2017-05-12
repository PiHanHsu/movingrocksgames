using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two_Players : MonoBehaviour {

	public GameObject Left_Missile;
	public GameObject Left_Launcher;
	public GameObject Right_Missile;
	public GameObject Right_Launcher;

	public GameObject Bubble;

	private GameObject right_Missile;
	private GameObject left_Missile;
	private GameObject bubble;

	private float bubble_time;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		bubble_time += Time.deltaTime;

		if (bubble_time > 10.0f) {
			bubble = Instantiate (Bubble, new Vector3 (0, -550, 0), Bubble.transform.rotation);
			bubble_time = 0f;
		}

		if (bubble != null) {
			bubble.transform.position += new Vector3 (0, 10f, 0);
		}


		if(Input.GetKeyDown(KeyCode.Z)){
			left_Missile = Instantiate (Left_Missile, Left_Launcher.gameObject.transform.position, transform.rotation);
		}

		if(Input.GetKeyDown(KeyCode.Slash)){
			right_Missile = Instantiate (Right_Missile, Right_Launcher.gameObject.transform.position, Right_Missile.transform.rotation);
		}
	}
}
