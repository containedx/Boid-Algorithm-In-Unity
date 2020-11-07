using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float Speed;

    // current position
    public Vector3 Position;

    // current Velocity
    public Vector3 Velocity; 

    // List of Neighbours - all other agents
    public List<Agent> Neighbours = new List<Agent>();

    // Neighbours which are in visual range 
    public List<Agent> surroundingNeighbours = new List<Agent>();

    // how far Agent can see
    public int Distance = 5; 


    void Update()
    {
        // Update position
        Position = transform.position;

        //Update surrounding neighbours
        UpdateNeighbours(); 

        //transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }

    public void UpdateNeighbours()
    {
        foreach(var neighbour in Neighbours)
        {
            if(Vector3.Distance(neighbour.Position, Position) <= Distance && !surroundingNeighbours.Contains(neighbour))
            {
                surroundingNeighbours.Add(neighbour);
            }
            else if(Vector3.Distance(neighbour.Position, Position) > Distance && surroundingNeighbours.Contains(neighbour))
            {
                surroundingNeighbours.Remove(neighbour); 
            }
        }
    }

}
