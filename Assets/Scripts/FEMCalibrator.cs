using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class FEMCalibrator : MonoBehaviour {

    /**
	                                            ^ V
	 .-------> X                                |
	 |  n4-------n3              (-U/2, V/2)n4-------n3(U/2, V/2)
	 |  |        |       map                |   |    |
	 v  |        |      ----->              |   .----|--> U
	 Y  |        |                          |        |
		n1-------n2             (-U/2, -V/2)n1-------n2(U/2, V/2)
		 Color Space                         Game Space
	**/

    public GameObject node1;
    public GameObject node2;
    public GameObject node3;
    public GameObject node4;

    public static float UVectorOfGameSpace = 960f;
	public static float VVectorOfGameSpace = 540f;

    public bool CalibrationMode = true;

    private KinectSensor kinectSensor;
    private CoordinateMapper coordinateMapper;
    private static Vector3 n1Position = new Vector3(-480, -270, 0);
    private static Vector3 n3Position = new Vector3(480, 270, 0);

    // Use this for initialization
    void Start () {
        this.kinectSensor = KinectSensor.GetDefault();
        coordinateMapper = this.kinectSensor.CoordinateMapper;

		string saved = PlayerPrefs.GetString ("Saved");
		if (saved == "Saved") {
			float n1_x = PlayerPrefs.GetFloat ("n1_x");
			float n1_y = PlayerPrefs.GetFloat ("n1_y");
			float n3_x = PlayerPrefs.GetFloat ("n3_x");
			float n3_y = PlayerPrefs.GetFloat ("n3_y");

			node1.transform.position = new Vector3 (n1_x, n1_y, 0);
			node3.transform.position = new Vector3 (n3_x, n3_y, 0);

		}

    }

    void Update()
    {
        if (CalibrationMode)
        {
            n1Position = node1.transform.position;
            n3Position = node3.transform.position;
        }
    }

    // Map camera point to game space
    public Vector3 MapWorldPointToColorSpace(Vector3 worldPoint) {
        Vector3 colorPoint;

        var U = UVectorOfGameSpace;
        var V = VVectorOfGameSpace;

        var x = U - worldPoint.x;
        var y = V - worldPoint.y;

        colorPoint = new Vector3(x, y, 0);

        return colorPoint;
    }

    // Map including area point to game space
    public Vector3 MapInducingPointToWorldSpace(ColorSpacePoint colorPoint)
    {
        Vector3 worldPoint;

        var n1 = MapWorldPointToColorSpace(n1Position);
        var n3 = MapWorldPointToColorSpace(n3Position);

        var U = UVectorOfGameSpace;
		var V = VVectorOfGameSpace;

		var u = (2 * colorPoint.X - n1.x - n3.x) * U / (n3.x - n1.x);
		var v = (2 * colorPoint.Y - n1.y - n3.y) * V / (n3.y - n1.y);

        worldPoint = new Vector3(u, v, 0);

        return worldPoint;
	}

    // Debug
    private void PrintInducingPointToWorldSpace(float X, float Y)
    {
        var colorPoint = new ColorSpacePoint();
        colorPoint.X = X;
        colorPoint.Y = Y;
        print("MAP (" + X + ", " + Y + ") to " + this.MapInducingPointToWorldSpace(colorPoint).ToString());
    }

    public void setN1Position(Vector3 position)
    {
        n1Position = position;
    }

    public void setN3Position(Vector3 position)
    {
        n3Position = position;
    }


	public void saveCalibrationData(){
		
		PlayerPrefs.SetFloat ("n1_x", n1Position.x);
		PlayerPrefs.SetFloat ("n1_y", n1Position.y);
		PlayerPrefs.SetFloat ("n3_x", n3Position.x);
		PlayerPrefs.SetFloat ("n3_y", n3Position.y);
		PlayerPrefs.SetString ("Saved", "Saved");
	}
}
