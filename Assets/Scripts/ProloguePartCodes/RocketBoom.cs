using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBoom : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rocket")
        {
           other.gameObject.SetActive(false);
        }
    }
}
