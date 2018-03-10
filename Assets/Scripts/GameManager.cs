using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager s_instance;
    public static GameManager instance {
        get {
            if(!s_instance) {
                s_instance = GameObject.Find("GameManager").GetComponent<GameManager>();
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

    public static BombQueue BombQueue {
        get {
            return instance.bombQueue;
        }
    }
    public BombQueue bombQueue;

    public static InputManager InputManager {
        get {
            return instance.inputManager;
        }
    }
    public InputManager inputManager;

    void Start() {
        InputManager.enabled = false;
    }

    public static void StartGame() {
        InputManager.enabled = true;
    }
}
