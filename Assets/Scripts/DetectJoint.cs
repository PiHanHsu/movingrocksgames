using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class DetectJoint : MonoBehaviour {

    public GameObject bodySrcManager;
    public GameObject mappingSystem;
    public JointType trackedJoint;
    public float multiplier = 1f;

    private FEMCalibrator FEMCalibrator;
    private KinectSensor kinectSensor;
    private CoordinateMapper coordinateMapper;
    private BodySourceManager bodyManager;
    private Body[] bodies;

    // Use this for initialization
    void Start () {
		if(bodySrcManager == null)
        {
            print("xxx");
        }
        else
        {
            bodyManager = bodySrcManager.GetComponent<BodySourceManager>();
            this.kinectSensor = KinectSensor.GetDefault();
            coordinateMapper = this.kinectSensor.CoordinateMapper;
            FEMCalibrator = mappingSystem.GetComponent<FEMCalibrator>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (bodyManager == null)
        {
            // print("bodyManager is null");
            return;
        }
        bodies = bodyManager.GetData();

        if(bodies == null)
        {
            // print("body is null");
            return;
        }
        foreach (var body in bodies)
        {
            if (body == null)
            {
                continue;
            }
            if (body.IsTracked)
            {
                // print("body is tracked");
                var cameraPos = body.Joints[trackedJoint].Position;
                var colorPos = coordinateMapper.MapCameraPointToColorSpace(cameraPos);
                var worldPos = FEMCalibrator.MapInducingPointToWorldSpace(colorPos);

                if (!Double.IsInfinity(worldPos.x) && !Double.IsInfinity(worldPos.y))
                {
                    gameObject.transform.position = worldPos;
                }

				if (this.trackedJoint == JointType.HandRight) {
				  
					print ("colorPos: " + colorPos.X);
					print ("worldPos: " + worldPos);
				
				}
					
            }
        }
     }
}
