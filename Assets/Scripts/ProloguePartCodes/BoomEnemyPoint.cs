using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEnemyPoint : MonoBehaviour
{
    public ParticleSystem particle;
    private void Start()
    {
      particle.Pause();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Rocket")
        {
           gameObject.SetActive(false);
           particle.Play();
        }
    }
}
