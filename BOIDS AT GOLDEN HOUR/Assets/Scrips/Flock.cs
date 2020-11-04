using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public int count = 100; 
    List<Agent> agents = new List<Agent>();

    public Agent prefab; 

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<count; i++)
        {
            Agent newAgent = Instantiate(
                prefab,
                Random.insideUnitCircle * count,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
            );

            newAgent.name = "agent" + i;
            agents.Add(newAgent); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
