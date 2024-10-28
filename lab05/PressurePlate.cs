using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float launchForce = 3.0f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Siuuuu");
            MovePlayerWithCharacterController player = other.GetComponent<MovePlayerWithCharacterController>();
            player.Launch(launchForce);
        }
    }
}
