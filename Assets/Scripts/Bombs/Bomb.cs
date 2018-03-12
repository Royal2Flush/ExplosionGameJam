using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bomb : MonoBehaviour {
    
	public float force;
    public int orderNumber { get; private set; }
    public Animator animator;

	private TextMesh infoText;


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

		if (infoText == null) {
			infoText = GetComponentInChildren<TextMesh> ();
		}

		infoText.text = (number + 1).ToString ();
    }

	public void SetLabelActive (bool isActive)
	{
		if (isActive) {
			infoText.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
		} else {
			infoText.color = new Color (0.0f, 0.0f, 0.0f, 0.3f);
		}
	}

	public void SetTransparent (bool trans) {

		if (trans) {
			//GetComponent<SpriteRenderer> ().color = new Color (1f,1f,1f,0.5f);
		} else {
			//GetComponent<SpriteRenderer> ().color = new Color (1f,1f,1f,0.5f);
		}
	}

    protected float ForceRelativeToDistance(float distance) {
        print(1 / distance * force);
        print(1 / Mathf.Clamp(distance, 1, Mathf.Infinity) * force);
        return (1 / Mathf.Clamp(distance, 1, Mathf.Infinity) * force);
    }
}
