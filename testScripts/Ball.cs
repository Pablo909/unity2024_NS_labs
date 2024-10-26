using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public float force = 10.0f;
    public Rigidbody rb;
    
    void Start()
    {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
