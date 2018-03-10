using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager s_instance;
    public static LevelManager instance {
        get {
            if(!s_instance) {
                s_instance = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            }
            return s_instance;
        }
    }

    public static Ball Ball {
        get {
            return instance.ball;
        }
    }
    public Ball ball;
}
