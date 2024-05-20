using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyPlane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rocket")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
