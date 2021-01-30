using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Calculations : MonoBehaviour
{
    public FlockManager Flock;

    // Update is called once per frame
    void Update()
    {
        //MeasureHowFastTheyGetTogether();
    }


    public void MeasureHowFastTheyGetTogether()
    {
        var boids = Flock.boids;

        var i = 0;    //Random.Range(0, 49);

        if (boids[i].localNeighbours.Count == Flock.count - 1)
        {
            MeasureTime();
        }
    }

    public void MeasureTime()
    {
        var time = Time.realtimeSinceStartup;
        Debug.Log(time);
    }

}
