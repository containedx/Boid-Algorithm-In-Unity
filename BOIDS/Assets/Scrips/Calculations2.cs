using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculations2 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "boid")
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
