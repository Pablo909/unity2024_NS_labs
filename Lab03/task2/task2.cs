using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class task2 : MonoBehaviour
{
    public float speed=4.0f;
    Vector3 pointA;
    Vector3 pointB;

    void Start()
    {
        pointA = new Vector3(0, 0, 0);
        pointB = new Vector3(10, 0, 0);
    }

    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }

}
