using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cohesion : MonoBehaviour
{
    public Vector3 CalculateCohesion(Boid boid)
    {
        // Calculate average position of local neighbourhood

        Vector3 pos = Vector3.zero;

        if (boid.localNeighbours.Count == 0)
            return pos; 

        foreach(var neighbour in boid.localNeighbours)
        {
            pos += neighbour.Position; 
        }
        pos /= boid.localNeighbours.Count;

        return pos; 
    }
}
