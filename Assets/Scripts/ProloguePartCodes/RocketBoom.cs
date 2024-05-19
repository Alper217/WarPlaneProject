using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBoom : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
    }
}
