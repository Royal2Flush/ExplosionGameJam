using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclularBomb : Bomb {
    public override void Explode()
    {
        base.Explode();

        Vector2 direction = (ballPosition - (Vector2)transform.position).normalized;
        float distance = Vector2.Distance(ballPosition, transform.position);

        GameManager.Ball.AddForce(direction * ForceRelativeToDistance(distance));

        GameManager.SoundManager.Explosion();
    }
}
