using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float moveSpeed = 200f; // Hareket h�z�

    void Update()
    {
        // Mermiyi ileri do�ru hareket ettir
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
