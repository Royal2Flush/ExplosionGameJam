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

    public void PushBomb(Bomb bomb)
    {
        queue.Enqueue(bomb);
        bomb.SetOrderNumber(queue.Count);
    }

    public void ExplodeNextBomb()
    {
        Bomb currentBomb = queue.Dequeue();
        currentBomb.Explode();
    }

    public Bomb GetNextBomb()
    {
        return queue.Peek();
    }

    /*public void ChangeOrderNumber(Bomb bomb, int newPosition)
    {
        int oldPosition = bomb.orderNumber;

        if (oldPosition == newPosition)
        {
            return;
        }

        Queue<Bomb> newQueue = new Queue<Bomb>();

        int firstToChange = Mathf.Min(oldPosition, newPosition);
        int lastToChange = Mathf.Max(oldPosition, newPosition);

        for (int i = 0; i < firstToChange - 1; i++)
        {
            newQueue.Enqueue(queue.Dequeue());
        }

        if (firstToChange == newPosition)
        {
            newQueue.Enqueue(bomb);
        }

        for (int i = )
    }

    public void ChangeOrderNumber(int oldPosition, int newPosition)
    {
        
    }*/
}
