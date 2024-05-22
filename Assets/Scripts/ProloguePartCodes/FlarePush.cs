using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlarePush : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject flare;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Vector3 spawnPosition = (spawnPoint.position + Vector3.back*Time.deltaTime);
            Instantiate(flare, spawnPosition, spawnPoint.rotation);
        }
    }
}
