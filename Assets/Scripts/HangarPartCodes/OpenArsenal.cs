using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenArsenal : MonoBehaviour
{
    public GameObject instructionForArsenal;
    public bool action = false;
    public Animator animator;
    public bool isClose = true;
    void Start()
    {
        isClose = true;
        instructionForArsenal.SetActive(false);
    }
    void Update()
    {
        OpenArsenalCap();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
           action = true;
           instructionForArsenal.SetActive(true);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        action = false;
        instructionForArsenal.SetActive(false);
    }

    void OpenArsenalCap()
    {
        if (action == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && isClose)
            {
                animator.SetBool("isClosed", true);
                isClose = false;
            }
            else if (Input.GetKeyDown(KeyCode.E) && isClose == false)
            {
                animator.SetBool("isClosed", false);
                isClose = true;
            }
        }
    }
}


