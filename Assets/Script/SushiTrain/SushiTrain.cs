using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiTrain : MonoBehaviour {
	public GameObject Fire;

	private GameObject fire;
	private float fireTime;
	// Use this for initialization
	void Start () {
		createFireTrain ();
	}
	
	// Update is called once per frame
	void Update () {
		
			
	}

	void createFireTrain(){


		float ranX1 = Random.Range (-800, 0);
		float ranX2 = Random.Range (0, 800);
		float ranY1 = Random.Range (200, 400);
		float ranY2 = Random.Range (-400, -200);
       


		for (int i = 0; i < 7; i++) {
			fire = Instantiate (Fire, new Vector3 (ranX1, 400, 0), Fire.transform.rotation);
			ranX1 += 100;
			fire = Instantiate (Fire, new Vector3 (ranX2, -400, 0), Fire.transform.rotation);
			ranX2 -= 100;
			fire = Instantiate (Fire, new Vector3 (800, ranY1, 0), Fire.transform.rotation);
			ranY1 -= 100;
			fire = Instantiate (Fire, new Vector3 (-800, ranY2, 0), Fire.transform.rotation);
			ranY2 += 100;

		}
	}
}
