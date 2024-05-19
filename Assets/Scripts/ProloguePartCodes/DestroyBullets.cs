using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullets : MonoBehaviour
{
    public int countDown;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyBullet();
    }
    void DestroyBullet()
    {
        if (countDown == 1000)
        {
            Destroy(gameObject);
        }
        else
        {
            countDown++;
        }
    }
}
