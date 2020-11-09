using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek 
{
    // steer towards target
    public static Vector3 CalculateSeek(Boid boid, Transform target)
    {
        Vector3 desired = Vector3.Normalize(target.position - boid.Position);
        return desired - boid.Velocity;
    }
}
