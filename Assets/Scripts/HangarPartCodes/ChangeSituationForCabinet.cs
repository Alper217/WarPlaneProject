using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ChangeSituationForCabinet : MonoBehaviour
{
    public GameObject instructionForCabinet;
    public bool action;
    public Animator AnimatorForLeft;
   // public Animator AnimatorForRight;
    public bool isPush;
    void Start()
    {
        isPush = true;
        instructionForCabinet.SetActive(false);
    }
    void Update()
    {
        OpenLeftCabinetCap();
       // OpenRightCabinetCap();
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
    void OpenLeftCabinetCap()
    {
        if (action == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && isPush)
            {
                AnimatorForLeft.SetBool("isClicked", true);
                isPush = false;
            }
            else if (Input.GetKeyDown(KeyCode.E) && isPush == false)
            {
                AnimatorForLeft.SetBool("isClicked", false);
                isPush = true;
            }
        }
    }
    /*void OpenRightCabinetCap()
    {
        if (action == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && isPush)
            {
                AnimatorForRight.SetBool("isPushed", true);
                isPush = false;
            }
            else if (Input.GetKeyDown(KeyCode.E) && isPush == false)
            {
                AnimatorForRight.SetBool("isPushed", false);
                isPush = true;
            }
        }
    }*/
}
