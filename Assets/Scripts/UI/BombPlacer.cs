using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombPlacer : MonoBehaviour {

	//private List<GameObject> bombs = new List<GameObject>();
	private GameObject bombToDrop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (bombToDrop == null) {
			return;
		}

		// Mouse pos in world coordinates
		Vector3 mousePos = new Vector3(
			Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
			Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0
		);

		// Rotate bomb
		if (Input.GetKey(KeyCode.LeftShift)) {
			bombToDrop.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - bombToDrop.transform.position);
		
		// Bomb locked to mouse pos
		} else {
			bombToDrop.transform.position = mousePos;
		}

		// Place bomb on click
		if (Input.GetMouseButtonDown(0))
		{
            RegisterBomb();
            bombToDrop = null;
		}
        
        if (Input.GetMouseButtonDown(1) && bombToDrop) {
            DeselectBomb();
        }
    }

    void RegisterBomb() {
        bombToDrop.GetComponent<Bomb>().SetTransparent(false);

        bombToDrop.transform.SetParent(GameManager.Bombs.transform);
        GameManager.BombQueue.PushBomb(bombToDrop.GetComponent<Bomb>());
    }

    public void SelectBomb(GameObject bombPrefab) {
		bombToDrop = Instantiate (bombPrefab);
        Bomb bombComponent = bombToDrop.GetComponent<Bomb>();
        bombComponent.SetTransparent (true);

		// Enum in list
		//bombs.Add (bombToDrop);
		//this.UpdateBombEnumeration ();
	}

    void DeselectBomb() {
        Destroy(bombToDrop);
        BombButton.ReturnBomb();
    }

/*	private void UpdateBombEnumeration() {  //Wofür ist das?
		int i = 1;
		foreach (GameObject bomb in this.bombs) {
			Debug.Log ("Bomb: " + i);
			i++;
		}
	}*/
}
