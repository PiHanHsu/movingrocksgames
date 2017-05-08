using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCalibrator : MonoBehaviour {

    private int xMod = 0;
    private int yMod = 0;
    private float scale = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        /* xMod = 0;
        yMod = 0;
        scale = 0f; */

        if (Input.GetKey(KeyCode.RightArrow))
        {
            xMod += 8;
            print("Right");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xMod -= 8;
            print("Left");
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            yMod += 8;
            print("Up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            yMod -= 8;
            print("Down");
        }
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            scale += 0.005f;
            print("Scale Up");
        }
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            scale -= 0.005f;
            print("Scale Down");
        }
    }

    public int getXMod ()
    {
        return xMod;
    }

    public int getYMod()
    {
        return yMod;
    }

    public float getScale()
    {
        return scale;
    }
}
