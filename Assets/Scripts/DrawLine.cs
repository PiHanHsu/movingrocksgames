using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

	private LineRenderer lineRenderer;
	private float counter;
	private float dist;

	public Transform origin;
	public Transform destination;

	public float lineDrawSpeed = 6f;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetPosition(0, origin.position);
		// lineRenderer.SetWidth(1f, 1f);
		lineRenderer.startWidth = 1f;
		lineRenderer.endWidth = 1f;

		dist = Vector3.Distance(origin.position, destination.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (counter < dist) {
			counter += 1f / lineDrawSpeed;

			float x = Mathf.Lerp(0, dist, counter);

			Vector3 originPoint = origin.position;
			Vector3 destinationPoint = destination.position;

			Vector3 pointAlongLine = x * Vector3.Normalize(destinationPoint - originPoint) + originPoint;

			lineRenderer.SetPosition(1, pointAlongLine);
		}
	}
}
