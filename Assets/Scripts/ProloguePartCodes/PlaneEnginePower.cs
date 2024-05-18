using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEnginePower : MonoBehaviour
{
    private float planeSpeed = 0;
    private float verticalSpeed;
    private float horizontalSpeed;
    private float turnSpeed = 45;
    void Update()
    {
        Time.timeScale = 0.6f;
        if (Input.GetKey(KeyCode.E))
        {
            planeSpeed += 1;
            Console.WriteLine("Hýz Arttýyor");
            if (planeSpeed >=100)
            {
                planeSpeed = 100;
            }
        }
        if (Input.GetKey(KeyCode.Q))
        {
            planeSpeed -= 1;
            Console.WriteLine("Hýz Azalýyor");
            if (planeSpeed < 0)
                planeSpeed = 0;
        }
        horizontalSpeed = Input.GetAxis("Horizontal");
        verticalSpeed = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * planeSpeed);
        transform.Rotate(Vector3.right * Time.deltaTime * verticalSpeed * turnSpeed);
        transform.Rotate(Vector3.forward * Time.deltaTime * -horizontalSpeed * turnSpeed);
    }
}
