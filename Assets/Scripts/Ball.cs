using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    new public Rigidbody2D rigidbody;
    public SpriteRenderer sr;
    public Sprite playerAlive;
    public Sprite playerDead;
    private Vector2 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddForce(Vector2 force)
    {
        rigidbody.AddForce(force);
    }

    public void Die()
    {
        rigidbody.simulated = false;
        sr.sprite = playerDead;
    }

    public void Reset()
    {
        print("Reset Ball Position");
        transform.position = startPosition;
        rigidbody.velocity = Vector2.zero;

        rigidbody.simulated = true;
        sr.sprite = playerAlive;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Wall") {
            GameManager.SoundManager.HitWall();
        }
    }
}
