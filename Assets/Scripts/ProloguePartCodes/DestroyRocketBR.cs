using System.Collections;
using System.Collections.Generic;
using Tarodev;
using UnityEngine;

public class DestroyRocketBR : MonoBehaviour
{
    [SerializeField] GameObject missile1;
    [SerializeField] GameObject missile2;
    public int countdown;
    public bool isLoop;
    void Start()
    {
        isLoop = false;
        countdown = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.L))
        {
            isLoop = true;   
        }
       
        if (isLoop == true)
        {
         
            if (countdown == 1000)
            {
                Missile missile = GetComponent<Missile>();
                MissleLock missleLock = GetComponent<MissleLock>();
                Destroy(missile1);
                Destroy(missile2);
                missile.enabled = false;
                missleLock.enabled = false;
            }
            else countdown++;
        }

    }
}
