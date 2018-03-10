using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclularBomb : Bomb {
    public override void Explode() {
        Vector2 ballPosition = LevelManager.Ball.transform.position;

        Vector2 direction = (ballPosition - (Vector2)transform.position).normalized;

        float distance = Vector2.Distance(ballPosition, transform.position);

        LevelManager.Ball.AddForce(direction * (1 / distance * force));

        Destroy(gameObject);
    }
}
