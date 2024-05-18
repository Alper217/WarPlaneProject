using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunCode : MonoBehaviour
{
    [SerializeField] GameObject ammoPrefab;
    [SerializeField] GameObject plane;
    public int objectCount = 0;
    public int objectLimited = 5000;

    void Update()
    {
        if (Input.GetKey(KeyCode.F) && objectCount < objectLimited)
        {
            StartCoroutine(SpawnWithDelay());
        }
    }

    IEnumerator SpawnWithDelay()
    {
        Instantiate(ammoPrefab, plane.transform.position, plane.transform.rotation);
        objectCount++;
        yield return new WaitForSeconds(0.5f);
    }

}
