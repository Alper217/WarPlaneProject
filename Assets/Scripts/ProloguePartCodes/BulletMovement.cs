using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float moveSpeed = 200f; // Hareket hýzý

    void Update()
    {
        // Mermiyi ileri doðru hareket ettir
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
