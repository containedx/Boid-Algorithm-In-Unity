using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float speed;

    // List of Neighbours - all other agents
    public List<Agent> Neighbours = new List<Agent>(); 


    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

}
