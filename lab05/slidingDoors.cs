using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingDoors : MonoBehaviour
{
    public float doorSpeed = 1f;
    public float distance = 3.0f;
    private float startPos;
    private float endPos;
    private bool opening = false;
    private bool isRunning = false;

    private void Start()
    {
        startPos = transform.position.z;
        endPos = transform.position.z + distance;
    }

    private void Update()
    {
        if (isRunning)
        {
            if(opening)
            {
                transform.Translate(0, 0, doorSpeed * Time.deltaTime);
                if(transform.position.z > endPos)
                    isRunning=false;
            }
            else
            {
                transform.Translate(0, 0, -doorSpeed * Time.deltaTime);
                if(transform.position.z < startPos)
                    isRunning=false;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            opening = true;
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isRunning = true;
            opening = false;
        }
    }
}
