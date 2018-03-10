using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombQueue : MonoBehaviour {

    private Queue<Bomb> queue;

	// Use this for initialization
	void Start () {
        queue = new Queue<Bomb>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pushBomb(Bomb bomb)
    {
        queue.Enqueue(bomb);
        bomb.SetOrderNumber(queue.Count);
    }

    public void explodeNextBomb()
    {
        Bomb currentBomb = queue.Dequeue();
        currentBomb.Explode();
    }
}
