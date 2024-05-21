using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRadar : MonoBehaviour
{
    public int rotateSpeed;
    void Update()
    {
        transform.Rotate(0, rotateSpeed*Time.deltaTime, 0); 
    }
}
