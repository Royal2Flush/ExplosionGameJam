using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bomb : MonoBehaviour {
    public float force;

    public int orderNumber { get; private set; }

    public Animator animator;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}


    public abstract void Explode();

    public abstract void Reset();

    public void SetOrderNumber(int number)
    {
        orderNumber = number;

        // !! set GUI number 
    }

	public void SetTransparent (bool trans) {

		if (trans) {
			//GetComponent<SpriteRenderer> ().color = new Color (1f,1f,1f,0.5f);
		} else {
			//GetComponent<SpriteRenderer> ().color = new Color (1f,1f,1f,0.5f);
		}
	}
}
