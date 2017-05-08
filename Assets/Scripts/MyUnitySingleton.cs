using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUnitySingleton : MonoBehaviour {

    private static MyUnitySingleton instance = null;

    public static MyUnitySingleton Instance
    {
        get { return instance; }
    }

    void Awake()
    {

        if (instance != null && instance != this) {
            print("instance: " + instance.name);
            // print("this: " + this.name);
            if (instance.name != this.name)
            {
                Destroy(instance.gameObject);
                instance = this;
            } else
            {
                Destroy(this.gameObject);
            }
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
