using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    // List of All Agents
    public int count = 100; 
    List<Boid> boids = new List<Boid>();

    // Agent Prefab
    public Boid prefab; 

    void Start()
    {
        for(int i=0; i<count; i++)
        {
            Vector3 randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/10));
            Quaternion randomRotation = Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f));

            Boid newBoid = Instantiate(
                prefab,
                randomPosition,
                randomRotation,
                transform
            );

            newBoid.name = "boid " + i;
            boids.Add(newBoid); 
        }

        // Create List of Neighbours for each agent
        foreach(var boid in boids)
        {
            foreach(var a in boids)
            {
                if (a != boid)
                    boid.Neighbours.Add(a); 
            }
        }
    }
   
    void Update()
    {
        /*
         * for each boid
         * 
         * apply behaviors
         * calculate position
         * calculate velocity
         * 
         * */
    }
}
