using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class FlockManager : MonoBehaviour
{
    // List of All Agents
    public int count = 100; 
    List<Boid> boids = new List<Boid>();

    // Agent Prefab
    public Boid prefab;

    public float maxSpeed;

    // target Object
    public Transform Target;

    // Random Factors
    public bool RandomFactors; 

    //Weights
    [Range(0,1)]
    public float cohesionWeight;
    [Range(0, 1)]
    public float alignmentWeight;
    [Range(0, 1)]
    public float separationWeight;
    [Range(0, 3)]
    public float seekWeight;

    //Arrive
    public float arriveSlowingDistance;
    public float arriveMaxSpeed;

    // Visual Range - Field of View
    [Range(0,50)]
    public float Distance;
    [Range(0,360)]
    public float Angle;

    void Start()
    {
        InitFlock();
        CreateNeighbourhoods();
        if(RandomFactors)
        {
            RandomizeFactors();
        }
    }
   
    void Update()
    {
        UpdateMovement(); 
    }

    // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    private void UpdateMovement()
    {
        foreach(var boid in boids)
        {
            CalculateMove(boid);
        }
    }

    private void CalculateMove(Boid boid)
    {
        Vector3 cohesionVector, separationVector, alignmentVector, seekVector, arriveVector;
        // calculate behaviours
        cohesionVector = Cohesion.CalculateCohesion(boid) * cohesionWeight;
        separationVector = Separation.CalculateSeparation(boid) * separationWeight;
        alignmentVector = Alignment.CalculateAlignment(boid) * alignmentWeight;
        seekVector = Seek.CalculateSeek(boid, Target, maxSpeed) * seekWeight;
        arriveVector = Arrive.CalculateArrive(boid, Target, arriveSlowingDistance, arriveMaxSpeed);

        // calculate vector
        var newVelocity = boid.Velocity + cohesionVector + separationVector + alignmentVector + seekVector + arriveVector;
        var newPosition = boid.Position + newVelocity;

        // limit 
        newVelocity = LimitVelocity(newVelocity);

        boid.UpdateMove(newPosition, newVelocity);
    }

    private Vector3 LimitVelocity(Vector3 velocity)
    {
        if(velocity.magnitude > maxSpeed)
        {
            velocity /= velocity.magnitude;
            velocity *= maxSpeed; 
        }
        return velocity;
    }

    private void InitFlock()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 10));
            Quaternion randomRotation = Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f));

            Boid newBoid = Instantiate(
                prefab,
                randomPosition,           //new Vector3(randomPosition.x, 0, randomPosition.z), // 0 => on ground //randomPosition,
                randomRotation,
                transform
            );

            newBoid.name = "boid " + i;
            newBoid.Distance = Distance;
            newBoid.Angle = Angle;

            boids.Add(newBoid);
        }
    }

    private void CreateNeighbourhoods()
    {
        // Create List of Neighbours for each agent
        foreach (var boid in boids)
        {
            foreach (var a in boids)
            {
                if (a != boid)
                    boid.Neighbours.Add(a);
            }
        }
    }

    private void RandomizeFactors()
    {
        cohesionWeight = Random.Range(0.0f, 1.0f);
        alignmentWeight = Random.Range(0.0f, 1.0f);
        separationWeight = Random.Range(0.0f, 1.0f);

        seekWeight = Random.Range(0.0f, 3.0f);

        Angle = Random.Range(0.0f, 360.0f);
        Distance = Random.Range(0.0f, 50.0f);
    }
}
