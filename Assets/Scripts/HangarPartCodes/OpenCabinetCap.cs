using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCabinetCap : MonoBehaviour
{
    public GameObject instructionForCabinet;
    public bool action;
    public bool isClicked;
    public Animator animator;
    void Start()
    {
        isClicked = true;
        instructionForCabinet.SetActive(false);
    }
    void Update()
    {
        OpenTheCabinetCap();   
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            action = true;
            instructionForCabinet.SetActive(true);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            action = false;
            instructionForCabinet.SetActive(false);
        }
    }
    void OpenTheCabinetCap()
    {
        if (action == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && isClicked)
            {
                animator.SetBool("isClicked", true);
                isClicked = false;
            }
            else if (Input.GetKeyDown(KeyCode.E) && isClicked == false)
            {
                animator.SetBool("isClicked", false);
                isClicked = true;
            }
        }
    }
}
