using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBomb : Bomb {

    private const float catchRadius = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Explode()
    {
        // trigger animation

        if((GameManager.Ball.transform.position - gameObject.transform.position).magnitude < catchRadius)
        {
            GameManager.Ball.rigidbody.velocity = new Vector2(0, 0);
        }

        animator.SetTrigger("Explode");
    }

    public override void Reset() {
        animator.SetTrigger("Reset");
    }
}
