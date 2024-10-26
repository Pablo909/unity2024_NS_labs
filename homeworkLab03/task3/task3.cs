
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class task3 : MonoBehaviour
{
    public float speed=5.0f;
    private int forward = 1;
    /*
    1 - foward
    2 - right
    3 - down
    4 - left
    */
    Vector3 pointA;
    Vector3 pointB;
    Vector3 pointC;
    Vector3 pointD;

    private float a=10;
    void Start()
    {
        pointA = new Vector3(0, 0, 0);
        pointB = new Vector3(a, 0, 0);
        pointC = new Vector3(a, 0, a);
        pointD = new Vector3(0, 0, a);
    }

    void Update()
    {
        if(transform.position.x == 10.0 && transform.position.z == 0)
        {
            transform.Rotate(0,90,0);
            forward=2;
        }
        else if(transform.position.x == 10.0 && transform.position.z == 10.0)
        {
            transform.Rotate(0,90,0);
            forward=3;
        }
        else if(transform.position.x == 0 && transform.position.z == 10.0)
        {
            transform.Rotate(0,90,0);
            forward=4;
        }
        else if(transform.position.x == 0 && transform.position.z == 0)
        {
            transform.Rotate(0,90,0);
            forward=1;
        }
        if(forward==1)  transform.position = Vector3.MoveTowards(transform.position, pointB, speed * Time.deltaTime);
        else if (forward==2)  transform.position = Vector3.MoveTowards(transform.position, pointC, speed * Time.deltaTime);
        else if (forward==3)  transform.position = Vector3.MoveTowards(transform.position, pointD, speed * Time.deltaTime);
        else if (forward==4)  transform.position = Vector3.MoveTowards(transform.position, pointA, speed * Time.deltaTime);
    }
}
