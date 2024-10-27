using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalElevator : MonoBehaviour
{
    public float elevatorSpeed = 1f;
    public float distance = 6.0f;
    private float startPos;
    private float endPos;
    private bool isRunning = false;
    private bool movingForward = true;

    private void Start()
    {
        startPos = transform.position.x;
        endPos = transform.position.x + distance;
    }

    private void Update()
    {
        if (isRunning)
        {
            if(movingForward)
                transform.Translate(elevatorSpeed * Time.deltaTime, 0, 0);
            else
                transform.Translate(-elevatorSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x >= endPos)
                movingForward = false;
            else if (transform.position.x <= startPos)
                movingForward = true;
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
