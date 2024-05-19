using Tarodev;
using UnityEngine;

public class RocketLaunch : MonoBehaviour
{
    public float speed = 5f;
    public GameObject[] missiles;
    private int currentMissileIndex = 0;
    private bool[] missileMovement;
    private bool allMissilesLaunched = false;

    void Start()
    {
        missileMovement = new bool[missiles.Length];
    }

    void Update()
    {
        if (!allMissilesLaunched)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                LaunchMissile();
            }

            for (int i = 0; i < missiles.Length; i++)
            {
                if (missileMovement[i])
                {
                    MoveMissile(i);
                }
            }
        }
    }

    void LaunchMissile()
    {
        if (currentMissileIndex < missiles.Length)
        {
            missiles[currentMissileIndex].transform.parent = null;
            missileMovement[currentMissileIndex] = true;
            currentMissileIndex++;
        }
    }

    void MoveMissile(int index)
    {
        GameObject currentMissile = missiles[index];
        currentMissile.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (currentMissile.transform.position.z >= 30000)
        {
            missileMovement[index] = false;
        }
    }
}