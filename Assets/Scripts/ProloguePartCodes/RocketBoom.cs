using UnityEngine;

public class RocketBoom : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
            gameObject.SetActive(false);
    }
}
