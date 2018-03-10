using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    new public Rigidbody2D rigidbody;
    private Vector2 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddForce(Vector2 force) {
        rigidbody.AddForce(force);
    }

    public void Reset() {
        print("Reset Ball Position");
        transform.position = startPosition;
        rigidbody.velocity = Vector2.zero;
    }
}
