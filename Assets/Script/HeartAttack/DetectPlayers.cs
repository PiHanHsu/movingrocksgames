﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Windows.Kinect;

public class DetectPlayers : MonoBehaviour {

	public Material BoneMaterial;
	public BodySourceManager BodySrcManager;
	public GameObject Player1_LeftHand;
	public GameObject Player1_RightHand;
	public GameObject Player2_LeftHand;
	public GameObject Player2_RightHand;
	public JointType TrackedJoint;
	public Text TrackingBodiesText;

	public GameObject mappingSystem;
	private FEMCalibrator FEMCalibrator;

	private BodySourceManager bodyManager;
	private KinectSensor kinectSensor;
	private CoordinateMapper coordinateMapper;
	private Body[] bodies;

	private GameObject _player1Object;
	private GameObject _player2Object;

	private Body _player1;
	private Body _player2;

	private Body _tempPlayer;

	private GameObject _player1_LeftHand;
	private GameObject _player1_RightHand;
	private GameObject _player2_LeftHand;
	private GameObject _player2_RightHand;


	private int _trackBodyCount;
	private float _limitZ = 5f;
	private float _limitX = -2.5f;


	private Dictionary<ulong, GameObject> _Bodies = new Dictionary<ulong, GameObject>();
	private Dictionary<JointType, JointType> _BoneMap = new Dictionary<JointType, JointType>()
	{
		{ Windows.Kinect.JointType.FootLeft,  Windows.Kinect.JointType.AnkleLeft },
		{ Windows.Kinect.JointType.AnkleLeft, Windows.Kinect.JointType.KneeLeft },
		{ Windows.Kinect.JointType.KneeLeft, Windows.Kinect.JointType.HipLeft },
		{ Windows.Kinect.JointType.HipLeft, Windows.Kinect.JointType.SpineBase },

		{ Windows.Kinect.JointType.FootRight, Windows.Kinect.JointType.AnkleRight },
		{ Windows.Kinect.JointType.AnkleRight, Windows.Kinect.JointType.KneeRight },
		{ Windows.Kinect.JointType.KneeRight, Windows.Kinect.JointType.HipRight },
		{ Windows.Kinect.JointType.HipRight, Windows.Kinect.JointType.SpineBase },

		{ Windows.Kinect.JointType.HandTipLeft, Windows.Kinect.JointType.HandLeft },
		{ Windows.Kinect.JointType.ThumbLeft, Windows.Kinect.JointType.HandLeft },
		{ Windows.Kinect.JointType.HandLeft, Windows.Kinect.JointType.WristLeft },
		{ Windows.Kinect.JointType.WristLeft, Windows.Kinect.JointType.ElbowLeft },
		{ Windows.Kinect.JointType.ElbowLeft, Windows.Kinect.JointType.ShoulderLeft },
		{ Windows.Kinect.JointType.ShoulderLeft, Windows.Kinect.JointType.SpineShoulder },

		{ Windows.Kinect.JointType.HandTipRight, Windows.Kinect.JointType.HandRight },
		{ Windows.Kinect.JointType.ThumbRight, Windows.Kinect.JointType.HandRight },
		{ Windows.Kinect.JointType.HandRight, Windows.Kinect.JointType.WristRight },
		{ Windows.Kinect.JointType.WristRight, Windows.Kinect.JointType.ElbowRight },
		{ Windows.Kinect.JointType.ElbowRight, Windows.Kinect.JointType.ShoulderRight },
		{ Windows.Kinect.JointType.ShoulderRight, Windows.Kinect.JointType.SpineShoulder },

		{ Windows.Kinect.JointType.SpineBase, Windows.Kinect.JointType.SpineMid },
		{ Windows.Kinect.JointType.SpineMid, Windows.Kinect.JointType.SpineShoulder },
		{ Windows.Kinect.JointType.SpineShoulder, Windows.Kinect.JointType.Neck },
		{ Windows.Kinect.JointType.Neck, Windows.Kinect.JointType.Head },
	};

	// Use this for initialization
	void Start () {

		if (BodySrcManager == null)
		{
			Debug.Log("Assign Game Object with Body Source Manager");
		}
		else
		{
			Debug.Log("Started!");
			bodyManager = BodySrcManager.GetComponent<BodySourceManager>();
			this.kinectSensor = KinectSensor.GetDefault ();
			coordinateMapper = this.kinectSensor.CoordinateMapper;
			FEMCalibrator = mappingSystem.GetComponent<FEMCalibrator>();
			if (bodyManager == null)
			{
				Debug.Log("bodyManager is null when start");
				return;
			}
			InitPlayers ();
		}
	}

	void InitPlayers() {
		if (_player1_LeftHand != null) {
			Destroy (_player1_LeftHand);
		}
		_player1_LeftHand = Instantiate (Player1_LeftHand, new Vector3 (0, 0, 0), transform.rotation);
		_player1_LeftHand.SetActive (false);

		if (_player1_RightHand != null) {
			Destroy (_player1_RightHand);
		}
		_player1_RightHand = Instantiate (Player1_RightHand, new Vector3 (0, 0, 0), transform.rotation);
		_player1_RightHand.SetActive (false);

		if (_player2_LeftHand != null) {
			Destroy (_player2_LeftHand);
		}
		_player2_LeftHand = Instantiate (Player2_LeftHand, new Vector3 (0, 0, 0), transform.rotation);
		_player2_LeftHand.SetActive (false);

		if (_player2_RightHand != null) {
			Destroy (_player2_RightHand);
		}
		_player2_RightHand = Instantiate (Player2_RightHand, new Vector3 (0, 0, 0), transform.rotation);
		_player2_RightHand.SetActive (false);
	
	}


	// Update is called once per frame
	void Update () {

		/*
		if (GameControl.gameover) {
			_player1 = null;
			_player2 = null;
		}
		*/

		if (bodyManager == null)
		{
			Debug.Log("bodyManager is null");
			return;
		}

		bodies = bodyManager.GetData();

		if (bodies == null)
		{
			Debug.Log("bodies is null");
			return;
		}

		//bodies = Array.FindAll(bodies, body => (body.Joints[TrackedJoint].Position.Z < _limitZ && body.Joints[TrackedJoint].Position.X > _limitX));

		List<ulong> trackedIds = new List<ulong>();
		List<Body> trackedBodies = new List<Body> ();

		foreach(var body in bodies)
		{
			if (body == null)
			{
				continue;
			}

			if(body.IsTracked)
			{
				print ("body is Tracked!!");
				trackedIds.Add (body.TrackingId);
				trackedBodies.Add (body);
				if (_player1 == null) {
					_player1 = body;
					print ("Player1: " + _player1.TrackingId);

				}

				if (_player1 != null) {
					if (body.TrackingId != _player1.TrackingId) {
						_player2 = body;
						print ("Player2: " + _player2.TrackingId);
					}

					if (_player2 != null) {
						if (_player1.Joints [TrackedJoint].Position.X > _player2.Joints [TrackedJoint].Position.X) {
							_tempPlayer = _player1;
							_player1 = _player2;
							_player2 = _tempPlayer;
						}
					}

				}
				/*
				if (trackedBodies.Count > 1) {
					if (body.TrackingId != _player1.TrackingId) {
						_player2 = body;
						print ("Player2: " + _player2.TrackingId);
					}

					if (_player2 != null) {
						if (_player1.Joints [TrackedJoint].Position.X > _player2.Joints [TrackedJoint].Position.X) {
							_tempPlayer = _player1;
							_player1 = _player2;
							_player2 = _tempPlayer;
						}
					}

				} 
				*/
			}
		}

		List<ulong> knownIds = new List<ulong>(_Bodies.Keys);

		// First delete untracked bodies
		foreach(ulong trackingId in knownIds)
		{
			if(!trackedIds.Contains(trackingId))
			{
				Destroy(_Bodies[trackingId]);
				_Bodies.Remove(trackingId);
				print ("Destroy!");
			}
		}
		/*
		foreach(var body in bodies)
		{
			if (body == null)
			{
				continue;
			}

			if(body.IsTracked)
			{
				if(!_Bodies.ContainsKey(body.TrackingId))
				{
					_Bodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
				}

				RefreshBodyObject(body, _Bodies[body.TrackingId]);
			}
		}

        */


		if (_player1 != null) {

			_player1_RightHand.SetActive (true);
			var cameraPos_r = _player1.Joints[JointType.WristLeft].Position;
			var colorPos_r = coordinateMapper.MapCameraPointToColorSpace(cameraPos_r);
			var worldPos_r = FEMCalibrator.MapInducingPointToWorldSpace(colorPos_r);

			if (!Double.IsInfinity(worldPos_r.x) && !Double.IsInfinity(worldPos_r.y))
			{
				_player1_RightHand.transform.position = worldPos_r;
			}

			_player1_LeftHand.SetActive (true);
			var cameraPos_l = _player1.Joints[JointType.WristRight].Position;
			var colorPos_l = coordinateMapper.MapCameraPointToColorSpace(cameraPos_l);
			var worldPos_l = FEMCalibrator.MapInducingPointToWorldSpace(colorPos_l);

			if (!Double.IsInfinity(worldPos_l.x) && !Double.IsInfinity(worldPos_l.y))
			{
				_player1_LeftHand.transform.position = worldPos_l;
			}

		} else {
			_player1_LeftHand.SetActive (false);
			_player1_RightHand.SetActive (false);
		}

		if (_player2 != null) {

			_player2_RightHand.SetActive (true);
			var cameraPos_r = _player2.Joints[JointType.WristLeft].Position;
			var colorPos_r = coordinateMapper.MapCameraPointToColorSpace(cameraPos_r);
			var worldPos_r = FEMCalibrator.MapInducingPointToWorldSpace(colorPos_r);

			if (!Double.IsInfinity(worldPos_r.x) && !Double.IsInfinity(worldPos_r.y))
			{
				_player2_RightHand.transform.position = worldPos_r;
			}

			_player2_LeftHand.SetActive (true);
			var cameraPos_l = _player2.Joints[JointType.WristRight].Position;
			var colorPos_l = coordinateMapper.MapCameraPointToColorSpace(cameraPos_l);
			var worldPos_l = FEMCalibrator.MapInducingPointToWorldSpace(colorPos_l);

			if (!Double.IsInfinity(worldPos_l.x) && !Double.IsInfinity(worldPos_l.y))
			{
				_player2_LeftHand.transform.position = worldPos_l;
			}

		} else {
			_player2_LeftHand.SetActive (false);
			_player2_RightHand.SetActive (false);
		}



		//TrackingBodiesText.text = "Tracking Bodies: " + trackedBodies.Count;

	}
		
	/*
	private GameObject CreateBodyObject(ulong id)
	{
		GameObject body = new GameObject("Body:" + id);

		for (Windows.Kinect.JointType jt = Windows.Kinect.JointType.SpineBase; jt <= Windows.Kinect.JointType.ThumbRight; jt++)
		{
			GameObject jointObj = GameObject.CreatePrimitive(PrimitiveType.Cube);

			LineRenderer lr = jointObj.AddComponent<LineRenderer>();
			lr.SetVertexCount(2);
			lr.material = BoneMaterial;
			lr.SetWidth(0.05f, 0.05f);

			jointObj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			jointObj.name = jt.ToString();
			jointObj.transform.parent = body.transform;
		}

		return body;
	}

	private void RefreshBodyObject(Body body, GameObject bodyObject)
	{
		for (Windows.Kinect.JointType jt = Windows.Kinect.JointType.SpineBase; jt <= Windows.Kinect.JointType.ThumbRight; jt++)
		{
			Windows.Kinect.Joint sourceJoint = body.Joints[jt];
			Windows.Kinect.Joint? targetJoint = null;

			if(_BoneMap.ContainsKey(jt))
			{
				targetJoint = body.Joints[_BoneMap[jt]];
			}

			Transform jointObj = bodyObject.transform.FindChild(jt.ToString());
			jointObj.localPosition = GetVector3FromJoint(sourceJoint);

			LineRenderer lr = jointObj.GetComponent<LineRenderer>();
			if(targetJoint.HasValue)
			{
				lr.SetPosition(0, jointObj.localPosition);
				lr.SetPosition(1, GetVector3FromJoint(targetJoint.Value));
				lr.SetColors(GetColorForState (sourceJoint.TrackingState), GetColorForState(targetJoint.Value.TrackingState));
			}
			else
			{
				lr.enabled = false;
			}
		}
	}

	private static Color GetColorForState(TrackingState state)
	{
		switch (state)
		{
		case Windows.Kinect.TrackingState.Tracked:
			return Color.green;

		case Windows.Kinect.TrackingState.Inferred:
			return Color.red;

		default:
			return Color.black;
		}
	}

	private static Vector3 GetVector3FromJoint(Windows.Kinect.Joint joint)
	{

		float x = (joint.Position.X * 15 + (80f)) * 4f / 18f;
		float y = (joint.Position.Y * 5 - (5f)) * 3f / 5f;
		return new Vector3(x,  y, -1);
	}
*/
}
