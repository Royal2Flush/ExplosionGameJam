using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BombButton : MonoBehaviour {

	public int numBombs;

	private Text infoText;

    static BombButton lastClicked;  //This is a temporary fix, to enable returning bombs with leftclick. Maybe i will change this.

	// Use this for initialization
	void Start () {
		infoText = GetComponentInChildren<Text> ();
		updateInfoText ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void placedBomb () {
        lastClicked = this;
		numBombs -= 1;
		updateInfoText ();
	}

	private void updateInfoText () {
		if (numBombs <= 0) {
			gameObject.SetActive (false);
			return;
		}

		infoText.text = numBombs.ToString();
	}

    public static void ReturnBomb() {
        lastClicked.numBombs++;
        lastClicked.updateInfoText();
    }
}
