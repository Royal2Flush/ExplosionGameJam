﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombQueue
{
    private List<Bomb> queue;
    private int currentIndex;

	public BombQueue()
    {
        queue = new List<Bomb>();
	}

    public void PushBomb(Bomb bomb)
    {
        queue.Add(bomb);
        bomb.SetOrderNumber(queue.Count - 1); // start with 0
    }

    public void RemoveBomb(Bomb bomb)
    {
        RemoveBomb(bomb.orderNumber);
    }

    public void RemoveBomb(int number)
    {
        if (number < 0 || number >= queue.Count)
        {
            Debug.LogError("Trying to remove a bomb not in the queue from the BombQueue!");
            return;
        }
        queue.RemoveAt(number);
        for (int i = number; i < queue.Count; i++)
        {
            Debug.Log("Updating order number of new bomb " + i.ToString());
            queue[i].SetOrderNumber(i);
        }
    }

    public void RemoveLast()
    {
        RemoveBomb(queue.Count - 1);
    }

    public void ExplodeNextBomb()
    {
        if (currentIndex > queue.Count - 1)
        {
            Debug.Log("You tried to explode more bombs than there are.");
            return;
        }
        queue[currentIndex].Explode();
        currentIndex++;
    }

    public Bomb GetNextBomb()
    {
        return queue[currentIndex];
    }

    public void OnGameStart()
    {
        currentIndex = 0;
    }

    public void OnGameEnd()
    {
        ResetAllBombs();
    }

    public void MoveBombUpInOrder(Bomb bomb)
    {
        MoveBombUpInOrder(bomb.orderNumber);
    }

    public void MoveBombUpInOrder(int bombNumber)
    {
        if(bombNumber <= 0)
        {
            Debug.Log("Tried to move the first bomb up in order");
            return;
        }
        SwapBombs(bombNumber, bombNumber - 1);
    }

    public void MoveBombDownInOrder(Bomb bomb)
    {
        MoveBombDownInOrder(bomb.orderNumber);
    }

    public void MoveBombDownInOrder(int bombNumber)
    {
        if (bombNumber >= queue.Count - 1)
        {
            Debug.Log("Tried to move the last bomb down in order");
            return;
        }
        SwapBombs(bombNumber, bombNumber + 1);
    }

    private void SwapBombs(int bombNumberA, int bombNumberB)
    {
        Bomb tempBomb = queue[bombNumberA];
        queue[bombNumberA] = queue[bombNumberB];
        queue[bombNumberA].SetOrderNumber(bombNumberA);
        queue[bombNumberB] = tempBomb;
        queue[bombNumberB].SetOrderNumber(bombNumberB);
    }

    private void ResetAllBombs()
    {
        foreach (Bomb bomb in queue)
        {
            bomb.Reset();
        }
    }
}
