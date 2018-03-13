using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombPlacer : MonoBehaviour {

	private GameObject bombToDrop;
    private Bomb bombComponent;
    private bool skipInputHandlingThisFrame;

	// Use this for initialization
	void Start ()
    {
        skipInputHandlingThisFrame = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (bombToDrop == null) // currently not placing a bomb
        {
			return;
		}

        MoveBomb();

		if(!skipInputHandlingThisFrame)
        {
            HandleInput();
        }

        skipInputHandlingThisFrame = false;
    }

    private void MoveBomb()
    {
        // Mouse pos in world coordinates
        Vector3 mousePos = new Vector3(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0
            );

        // Rotate bomb
        if (Input.GetKey(KeyCode.LeftShift))
        {
            bombToDrop.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - bombToDrop.transform.position);

            // Bomb locked to mouse pos
        }
        else
        {
            bombToDrop.transform.position = mousePos;
        }
    }

    private void HandleInput()
    {
        // Place bomb on click
        if (Input.GetMouseButtonDown(0))
        {
            PlaceBomb();
        }

        // return bomb to menu on right click
        if (Input.GetMouseButtonDown(1))
        {
            ReturnBombToMenu();
        }
    }

    public void PlaceBomb()
    {
        bombComponent.Place();
        bombToDrop = null;

        Debug.Log("Placing Bomb with order number " + bombComponent.orderNumber.ToString());
    }

    public void PickBombFromMenu(GameObject bombPrefab)
    {
        if (bombToDrop)
        {
            return;
        }
		bombToDrop = Instantiate (bombPrefab);
        bombToDrop.transform.SetParent(GameManager.Bombs.transform);

        bombComponent = bombToDrop.GetComponent<Bomb>();
        bombComponent.PickUp();

        GameManager.BombQueue.PushBomb(bombComponent);
    }

    public void PickBombFromWorld(Bomb bomb)
    {
        if (bombToDrop)
        {
            return;
        }
        bombToDrop = bomb.gameObject;
        bombComponent = bomb;

        bombComponent.PickUp();

        skipInputHandlingThisFrame = true;

        Debug.Log("Picking up bomb from world with order number " + bombComponent.orderNumber.ToString());
    }

    private void ReturnBombToMenu()
    {
        if (bombComponent.orderNumber >= 0) // if not, it's not in the bombqueue yet, i.e. it was picked from menu
        {
            GameManager.BombQueue.RemoveBomb(bombComponent);
        }

        foreach(BombButton button in GameManager.BombButtons)
        {
            if (button.GetBombType() == bombComponent.GetType())
            {
                button.AddBomb();
                break;
            }
        }

        bombComponent = null;
        Destroy(bombToDrop);
    }

/*	private void UpdateBombEnumeration() {  //Wofür ist das?
		int i = 1;
		foreach (GameObject bomb in this.bombs) {
			Debug.Log ("Bomb: " + i);
			i++;
		}
	}*/
}
