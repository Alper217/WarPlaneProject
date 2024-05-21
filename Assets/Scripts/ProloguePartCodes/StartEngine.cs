using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEngine : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startEngine;
    public int count;
    public bool isStart;
    public AudioClip running;
    private void Update()
    {
        Deneme deneme = GetComponent<Deneme>();
        if (Input.GetKey(KeyCode.I))
        {
            audioSource.PlayOneShot(startEngine);   
            isStart = true;
        }
        if (isStart ==true)
        {
            count++;
        }
        if (count == 6000)
        {
            deneme.enabled = true;
            count = 0;
            isStart = false;
        }
    }
    
}
