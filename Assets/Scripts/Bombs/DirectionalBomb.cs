using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalBomb : Bomb {

    public float explosionRadius = 30;

    public override void Explode()
    {
        base.Explode();

        GameManager.Ball.AddForce(CalculateForce());

        GameManager.SoundManager.Explosion();
        animator.SetTrigger("Explode");
    }

    private Vector2 CalculateForce()
    {
        Vector2 direction = (ballPosition - (Vector2)transform.position).normalized;
        float distance = Vector2.Distance(ballPosition, transform.position);

        float bombDirection = transform.rotation.eulerAngles.z;
        float ballDirection = Vector3.Angle(Vector2.up, direction);

        float relativeDirection = Mathf.Abs(ballDirection - bombDirection);
        float rotationMultiplier = Mathf.Clamp((explosionRadius - relativeDirection) / explosionRadius, 0, Mathf.Infinity);
                
        return (direction * rotationMultiplier * ForceRelativeToDistance(distance));
    }
}
