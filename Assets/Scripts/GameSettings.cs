using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {

    private static float _duration = 1;
    private static float _numberOfTarget = 1;
    private static float _sizeOfTarget = 2;

    public void SetDuration(float duration)
    {
        _duration = duration;
    }

    public void SetNumOfTarget(float numberOfTarget)
    {
        _numberOfTarget = numberOfTarget;
    }

    public void SetSizeOfTarget(float sizeOfTarget)
    {
        _sizeOfTarget = sizeOfTarget;
    }

    public float GetDuration()
    {
        return _duration;
    }

    public float GetNumOfTarget()
    {
        return _numberOfTarget;
    }

    public float GetSizeOfTarget()
    {
        return _sizeOfTarget;
    }
}
