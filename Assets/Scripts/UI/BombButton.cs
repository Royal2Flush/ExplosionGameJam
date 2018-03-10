using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BombButton : MonoBehaviour {

	public int numBombs;

	private Text infoText;

	// Use this for initialization
	void Start () {
		infoText = GetComponentInChildren<Text> ();
		updateInfoText ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void placedBomb () {
		numBombs -= 1;
		if (numBombs <= 0) {
			gameObject.SetActive (false);
			return;
		}

		updateInfoText ();
	}

	private void updateInfoText () {
		infoText.text = numBombs.ToString();
	}
}
