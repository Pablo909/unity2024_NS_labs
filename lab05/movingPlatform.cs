using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public List<Vector3> points = new List<Vector3>();
    public float platformSpeed = 3f;
    private bool isRunning = false;
    private bool movingForward = true; 
    private int i = 1;
    Vector3 targetPos;
    void Start()
    {

    }

    void Update()
    {
        if(isRunning)
        {
            targetPos = points[i];
            transform.position = Vector3.MoveTowards(transform.position, targetPos, platformSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                if (movingForward)
                {
                    i++;
                    if (i >= points.Count)
                    {
                        i--;
                        movingForward = false;
                    }
                }
                else
                {
                    i--;
                    if (i < 0)
                    {
                        i++;
                        movingForward = true;
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isRunning = false;
        }
    }
}
