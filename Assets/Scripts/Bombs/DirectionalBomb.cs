using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalBomb : Bomb {

    public float explosionRadius = 30;
    Vector2 ballPosition;

    public override void Explode() {
        ballPosition = LevelManager.Ball.transform.position;

        LevelManager.Ball.AddForce(calculateForce());

        Destroy(gameObject);
    }

    Vector2 calculateForce() {
        Vector2 direction = (ballPosition - (Vector2)transform.position).normalized;
        print("direction " + direction);
        float distance = Vector2.Distance(ballPosition, transform.position);
        print("distance " + distance);

        float bombDirection = transform.rotation.eulerAngles.z;
        print("bombDirection " + bombDirection);
        float ballDirection = Vector3.Angle(Vector2.up, direction);
        print("ballDirection " + ballDirection);

        float relativeDirection = Mathf.Abs(ballDirection - bombDirection);
        print("relativeDirection " + relativeDirection);
        float rotationMultiplier = Mathf.Clamp((explosionRadius - relativeDirection) / explosionRadius, 0, Mathf.Infinity);
        print("rotationMultiplier " + rotationMultiplier);

        float distanceMultiplier = 1 / distance * force;
        print("distanceMultiplier " + distanceMultiplier);

        print("return " + (direction * rotationMultiplier * distanceMultiplier));
        return (direction * rotationMultiplier * distanceMultiplier);
    }
}
