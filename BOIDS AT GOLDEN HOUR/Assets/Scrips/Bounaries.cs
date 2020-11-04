using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounaries : MonoBehaviour
{
    private Vector3 bounds;
    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }


    void Update()
    {
        if (transform.position.x > bounds.x)
            transform.Translate(Vector3.down * Time.deltaTime);

        if (transform.position.y > bounds.y)
            transform.Translate(Vector3.down * Time.deltaTime);
    }
}
