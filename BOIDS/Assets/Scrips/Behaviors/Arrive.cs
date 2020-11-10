using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour
{
    // slow down when close to target
    public static Vector3 CalculateArrive(Boid boid, Transform target, float slowingDistance, float maxSpeed)
    {
        Vector3 desired = Vector3.zero;

        var offset = target.position - boid.Position;
        var distance = Vector3.Distance(target.position, boid.Position);

        var rampedSpeed = maxSpeed * (distance / slowingDistance);
        var clippedSpeed = Math.Min(rampedSpeed, maxSpeed);

        desired = (clippedSpeed / distance) * offset;

        return desired - boid.Velocity;
    }
}
