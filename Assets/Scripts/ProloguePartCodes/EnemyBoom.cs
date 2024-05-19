using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoom : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rocket")
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
