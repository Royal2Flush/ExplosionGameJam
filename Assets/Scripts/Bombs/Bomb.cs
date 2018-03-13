using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bomb : MonoBehaviour {
    
	public float force;
    public int orderNumber { get; private set; }
    public Animator animator;

    protected Vector2 ballPosition;
    protected TextMesh infoText;


	// Use this for initialization
	void Start ()
    {
        //SetLabelActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void OnMouseDown()
    {
        if (GameManager.Gamestate == Gamestate.Placing)
        {
            GameManager.BombPlacer.PickBombFromWorld(this);
        }
    }

    public virtual void Explode()
    {
        SetLabelActive(false);
        animator.SetTrigger("Explode");

        ballPosition = GameManager.Ball.transform.position;
    }

    public virtual void Reset()
    {
        SetLabelActive(true);
        animator.SetTrigger("Reset");
    }

    public void SetOrderNumber(int number)
    {
        orderNumber = number;
		infoText.text = (orderNumber + 1).ToString ();
        Debug.Log("Changing order number");
    }

    public void PickUp()
    {
        if (infoText == null)
        {
            infoText = GetComponentInChildren<TextMesh>();
        }

        SetTransparent(true);
    }

    public void Place()
    {
        SetTransparent(false);
        SetLabelActive(true);
    }

	protected void SetLabelActive (bool isActive)
	{
		if (isActive)
        {
            infoText.gameObject.SetActive(true);
			//infoText.color = new Color (0.0f, 0.0f, 0.0f, 1.0f);
		}
        else
        {
            infoText.gameObject.SetActive(false);
            //infoText.color = new Color (0.0f, 0.0f, 0.0f, 0.3f);
		}
	}

	private void SetTransparent (bool trans) {

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
