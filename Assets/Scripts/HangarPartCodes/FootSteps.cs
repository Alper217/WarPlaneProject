using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip walking;
    public AudioClip running;
    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
           
            PlayClip(walking);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {   
            PlayClip(running);
        }
        else
        {
            audioSource.enabled = false;
        }
    }
    void PlayClip(AudioClip clip)
    {
        audioSource.enabled = true;
    }
}
