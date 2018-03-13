using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gamestate { Placing, Playing }

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

    public static Gamestate Gamestate
    {
        get
        {
            return instance.gamestate;
        }
    }
    public Gamestate gamestate;

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

    public static BombPlacer BombPlacer
    {
        get
        {
            return instance.bombPlacer;
        }
    }
    public BombPlacer bombPlacer;

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

    public static SoundManager SoundManager {
        get {
            return instance.soundManager;
        }
    }
    public SoundManager soundManager;

    public static BombButton[] BombButtons
    {
        get
        {
            return instance.bombButtons;
        }
    }
    public BombButton[] bombButtons;

    public GameObject startButton;
	public GameObject resetButton;

    void Start() {
        gamestate = Gamestate.Placing;

        InputManager.enabled = false;
        bombQueue = new BombQueue();
        bombButtons = GameObject.Find("BottomBar").GetComponentsInChildren<BombButton>();
    }

    public void StartGame() {
        gamestate = Gamestate.Playing;

        startButton.SetActive(false);
		resetButton.SetActive(true);
        BombQueue.OnGameStart();
        InputManager.enabled = true;
    }

	public void ResetGame() {
        gamestate = Gamestate.Placing;

		startButton.SetActive(true);
		resetButton.SetActive(false);
        BombQueue.OnGameEnd();
        InputManager.enabled = true;
        Ball.Reset();
    }

    public void ResetLevel() {
        CampaignManager.instance.ReloadLevel();
    }
}
