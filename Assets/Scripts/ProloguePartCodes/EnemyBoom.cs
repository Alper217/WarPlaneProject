using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoom : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Rocket")
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
