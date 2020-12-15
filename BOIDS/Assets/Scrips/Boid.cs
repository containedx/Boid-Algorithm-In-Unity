using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
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

    // visual view parameters
    public float Distance;
    public float Angle;

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
            /* --- field of view = 360 == all around boid
            if(Vector3.Distance(neighbour.Position, Position) <= Distance && !localNeighbours.Contains(neighbour)) */

            if (IsInFieldOfView(neighbour) && !localNeighbours.Contains(neighbour))
            {
                localNeighbours.Add(neighbour);
            }
            else if(!IsInFieldOfView(neighbour) && localNeighbours.Contains(neighbour))
            {
                localNeighbours.Remove(neighbour);
            }
        }
    }

    private bool IsInFieldOfView(Boid neighbour)
    {
        var distance = Vector3.Distance(neighbour.Position, Position);
        var distanceVector = neighbour.Position - Position;
        float angle = Vector3.Angle(distanceVector,transform.up);

        var distanceCondition = distance <= Distance;
        var angleCondition = angle <= Angle/2;

        //check distance and angle
        if (distanceCondition && angleCondition)
            return true;
        else 
            return false;
    }

}
