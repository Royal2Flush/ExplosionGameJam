using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombPlacer : MonoBehaviour {

	private List<GameObject> bombs = new List<GameObject>();
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
			bombToDrop.GetComponent<Bomb>().SetTransparent (false);
			bombToDrop = null;
		}
	}

	public void SelectBomb(GameObject bombPrefab) {
		bombToDrop = Instantiate (bombPrefab);
        bombToDrop.transform.SetParent(GameManager.Bombs.transform);
		bombToDrop.GetComponent<Bomb> ().SetTransparent (true);

		// Enum in list
		bombs.Add (bombToDrop);
		this.UpdateBombEnumeration ();
	}

	private void UpdateBombEnumeration() {
		int i = 1;
		foreach (GameObject bomb in this.bombs) {
			Debug.Log ("Bomb: " + i);
			i++;
		}
	}
}
