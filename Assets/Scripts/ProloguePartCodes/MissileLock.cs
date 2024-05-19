using Tarodev;
using UnityEngine;

public class MissileLock : MonoBehaviour
{
    private ScriptableObject m_ScriptableObject;
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
             Missile missle = GetComponent<Missile>();
            if (Input.GetKeyDown(KeyCode.L))
            {
                missle.enabled = true;
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