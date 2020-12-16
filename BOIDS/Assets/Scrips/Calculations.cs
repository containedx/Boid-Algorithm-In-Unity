using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculations : MonoBehaviour
{
    public FlockManager Flock;

    // Update is called once per frame
    void Update()
    {
        MeasureHowFastTheyGetTogether();
    }

    public void MeasureTime()
    {
        Debug.Log(Time.realtimeSinceStartup);
    }

    public void MeasureHowFastTheyGetTogether()
    {
        var boids = Flock.boids;

        var i = Random.Range(0, 49);

        if (boids[i].localNeighbours.Count == Flock.count-1)
            MeasureTime();
    }

}
