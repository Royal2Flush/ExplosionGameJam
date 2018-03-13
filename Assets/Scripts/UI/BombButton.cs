using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BombButton : MonoBehaviour {

	public int numBombs;
    public GameObject bombPrefab;    

	private Text infoText;

    //static BombButton lastClicked;  //This is a temporary fix, to enable returning bombs with leftclick. Maybe i will change this.

	// Use this for initialization
	void Start ()
    {
		infoText = GetComponentInChildren<Text> ();
		UpdateInfoText ();
	}
	
	void Update ()
    {
		
	}

	public void HandleClick ()
    {
        GameManager.BombPlacer.PickBombFromMenu(bombPrefab);
		numBombs -= 1;
		UpdateInfoText ();
	}

	private void UpdateInfoText ()
    {
		if (numBombs <= 0)
        {
			gameObject.SetActive (false);
			return;
		}
        else
        {
            gameObject.SetActive(true);
        }

		infoText.text = numBombs.ToString();
	}

    public void AddBomb()
    {
        numBombs++;
        UpdateInfoText();
    }

    public System.Type GetBombType()
    {
        return bombPrefab.GetComponent<Bomb>().GetType();
    }

}
