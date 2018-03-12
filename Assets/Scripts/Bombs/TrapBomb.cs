using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBomb : Bomb {

    //private const float catchRadius = 1;  this is now replaced by the force variable, so it can be changed in the inspector

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Explode()
    {
        // trigger animation

        if((GameManager.Ball.transform.position - gameObject.transform.position).magnitude < force)
        {
            GameManager.Ball.rigidbody.velocity = new Vector2(0, 0);
        }

        animator.SetTrigger("Explode");
    }

    public override void Reset() {
        animator.SetTrigger("Reset");
        SetLabelActive(true);
    }
}
