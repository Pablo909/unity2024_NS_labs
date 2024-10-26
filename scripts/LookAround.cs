using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // ruch wokół osi Y będzie wykonywany na obiekcie gracza, więc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;
    private float mouseXMove = 0f;
    private float mouseYMove = 0f;
    private float lockRotation = 0f;
    void Start()
    {
        // zablokowanie kursora na środku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy wartości dla obu osi ruchu myszy
        mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // wykonujemy rotację wokół osi Y
        player.Rotate(Vector3.up * mouseXMove);

        lockRotation -= mouseYMove;
        lockRotation = Mathf.Clamp(lockRotation, -90f, 90f);

        //Vector3 currentRotation = transform.localEulerAngles;
        //currentRotation.x = lockRotation;
        transform.localEulerAngles = new Vector3(lockRotation, 0.0f, 0.0f);

    
        // a dla osi X obracamy kamerę dla lokalnych koordynatów
        // -mouseYMove aby uniknąć ofektu mouse inverse
        //transform.Rotate(new Vector3(-lockRotation, 0f, 0f), Space.Self);

    }
}