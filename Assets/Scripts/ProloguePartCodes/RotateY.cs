using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{
    [SerializeField] GameObject B2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        B2.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
