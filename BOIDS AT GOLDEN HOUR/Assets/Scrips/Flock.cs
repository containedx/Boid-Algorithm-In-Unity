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
            Vector3 randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/10));
            Agent newAgent = Instantiate(
                prefab,
                randomPosition,
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
