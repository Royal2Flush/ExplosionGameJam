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

    public static GameObject Bombs {
        get {
            return instance.bombs;
        }
    }
    public GameObject bombs;

    public GameObject startButton;

    void Start() {
        InputManager.enabled = false;
    }

    public void StartGame() {
        startButton.SetActive(false);
        InputManager.enabled = true;
    }

    public void ResetGame() {
        InputManager.enabled = true;
        startButton.SetActive(true);
    }
}
