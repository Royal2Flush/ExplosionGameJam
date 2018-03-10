using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalBomb : Bomb {

    public float explosionRadius = 30;
    Vector2 ballPosition;

    public override void Explode() {
        ballPosition = GameManager.Ball.transform.position;

        GameManager.Ball.AddForce(calculateForce());

        Destroy(gameObject);
    }

    Vector2 calculateForce() {
        Vector2 direction = (ballPosition - (Vector2)transform.position).normalized;
        float distance = Vector2.Distance(ballPosition, transform.position);

        float bombDirection = transform.rotation.eulerAngles.z;
        float ballDirection = Vector3.Angle(Vector2.up, direction);

        float relativeDirection = Mathf.Abs(ballDirection - bombDirection);
        float rotationMultiplier = Mathf.Clamp((explosionRadius - relativeDirection) / explosionRadius, 0, Mathf.Infinity);

        float distanceMultiplier = 1 / distance * force;
        
        return (direction * rotationMultiplier * distanceMultiplier);
    }

    public override void Reset() {
        throw new NotImplementedException();
    }
}
