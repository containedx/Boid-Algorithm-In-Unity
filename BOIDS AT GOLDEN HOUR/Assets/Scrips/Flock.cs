using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    // List of All Agents
    public int count = 100; 
    List<Agent> agents = new List<Agent>();

    // Agent Prefab
    public Agent prefab; 

    void Start()
    {
        for(int i=0; i<count; i++)
        {
            Vector3 randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/10));
            Quaternion randomRotation = Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f));

            Agent newAgent = Instantiate(
                prefab,
                randomPosition,
                randomRotation,
                transform
            );

            newAgent.name = "agent" + i;
            agents.Add(newAgent); 
        }

        // Create List of Neighbours for each agent
        foreach(var agent in agents)
        {
            foreach(var a in agents)
            {
                if (a != agent)
                    agent.Neighbours.Add(a); 
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
