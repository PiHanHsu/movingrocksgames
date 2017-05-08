using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour {

    public GameObject TimeText;
    public GameObject BubbleNumText;
    public GameObject BubbleSizeText;

    public void setDurationText(float duration)
    {
        TimeText.GetComponent<Text>().text = "Duration: " + (duration * 30).ToString() + " secs";
    }

    public void setNumberOfTargetText(float numberOfTarget)
    {
        BubbleNumText.GetComponent<Text>().text = "Number of Bubble(s): " + numberOfTarget;
    }

    public void setSizeOfTargetText(float sizeOfTarget)
    {
        string sizeText = "Noarmal";
        switch (sizeOfTarget.ToString())
        {
            case "1":
                sizeText = "Small";
                break;
            case "2":
                sizeText = "Noarmal";
                break;
            case "3":
                sizeText = "Large";
                break;
        }
        BubbleSizeText.GetComponent<Text>().text = "Size of Bubble: " + sizeText;
    }
}
