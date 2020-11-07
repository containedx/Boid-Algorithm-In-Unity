using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cohesion : MonoBehaviour
{
    public Vector3 CalculateCohesion(Agent agent)
    {
        // Calculate average position of local neighbourhood

        Vector3 pos = Vector3.zero;

        if (agent.localNeighbours.Count == 0)
            return pos; 

        foreach(var neighbour in agent.localNeighbours)
        {
            pos = pos + neighbour.Position; 
        }
        return pos / agent.localNeighbours.Count; 
    }
}
