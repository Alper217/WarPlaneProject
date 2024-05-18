using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    public float speed = 3f;
    public GameObject[] bombs;
    private int currentBombIndex = 0;
    private bool[] bombsMovement;
    private bool allBombsLaunched = false;

    void Start()
    {
        bombsMovement = new bool[bombs.Length];
    }

    void Update()
    {
        if (!allBombsLaunched)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchMissile();
            }

            for (int i = 0; i < bombs.Length; i++)
            {
                if (bombsMovement[i])
                {
                    MoveMissile(i);
                }
            }
        }
    }

    void LaunchMissile()
    {
        if (currentBombIndex < bombs.Length)
        {
            bombs[currentBombIndex].transform.parent = null;
            bombsMovement[currentBombIndex] = true;
            currentBombIndex++;
        }
    }

    void MoveMissile(int index)
    {
        GameObject currentMissile = bombs[index];
        currentMissile.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        currentMissile.transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (currentMissile.transform.position.z >= 30000)
        {
            bombsMovement[index] = false;
        }
    }
}
