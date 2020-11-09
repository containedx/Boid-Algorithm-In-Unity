using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Rigidbody rigidBody;

    // current position
    public Vector3 Position;

    // current Velocity
    public Vector3 Velocity;

    // List of Neighbours - all other agents
    public List<Boid> Neighbours = new List<Boid>();

    // Neighbours which are in visual range 
    public List<Boid> localNeighbours = new List<Boid>();

    // how far Agent can see
    public int Distance;

    void Start()
    {
        // Init
        rigidBody = GetComponent<Rigidbody>();
        Position = transform.position;
        Velocity = rigidBody.velocity;
    }

    void Update()
    {
        //Update surrounding neighbours
        UpdateNeighbours();   
    }

    // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public void UpdateMove(Vector3 position, Vector3 velocity)
    {
        Position = position;
        Velocity = velocity;
        gameObject.transform.position = position;
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(velocity));
    }

    private void UpdateNeighbours()
    {
        foreach(var neighbour in Neighbours)
        {
            if(Vector3.Distance(neighbour.Position, Position) <= Distance && !localNeighbours.Contains(neighbour))
            {
                localNeighbours.Add(neighbour);
            }
            else if(Vector3.Distance(neighbour.Position, Position) > Distance && localNeighbours.Contains(neighbour))
            {
                localNeighbours.Remove(neighbour); 
            }
        }
    }

}
