using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SitToChairs : MonoBehaviour
{
    public GameObject chair1;
    public GameObject chair2;
    public GameObject chair3;
    public GameObject chair4;
    public Transform sitPosition;
    public Transform sitRotation;
    public Transform Character;
    private CharacterMovement ChrMovement;
    public GameObject instructionForSitToChair;
    public Animator AnimatorForSit;
    public bool action;
    public bool isSit;
    void Start()
    {
        ChrMovement = GetComponent<CharacterMovement>();
        ChrMovement.transform.position = transform.position;
        isSit = true;
        instructionForSitToChair.SetActive(false);
    }
    void Update()
    {
       SitToChair();
    }
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Chair1")
        {
            action = true;
            instructionForSitToChair.SetActive(true);
            if (isSit ==false)
            {
                sitPosition.transform.position = chair1.transform.position + new Vector3(0.2f,-1.5f,0);
                Character.transform.rotation = Quaternion.Euler(0, 79f, 0);
            }
        }
        else if (collider.gameObject.tag == "Chair2")
        {
            action = true;
            instructionForSitToChair.SetActive(true);
            if (isSit == false)
            {
                sitPosition.transform.position = chair2.transform.position + new Vector3(0.2f, -1.5f, 0);
                Character.transform.rotation = Quaternion.Euler(0, 50f, 0);
            }
        }
        else if (collider.gameObject.tag == "Chair3")
        {
            action = true;
            instructionForSitToChair.SetActive(true);
            if (isSit == false)
            {
                sitPosition.transform.position = chair3.transform.position + new Vector3(0.2f, -1.5f, 0);

                Character.transform.rotation = Quaternion.Euler(0, 19f, 0);
            }
        }
        else if (collider.gameObject.tag == "Chair4")
        {
            action = true;
            instructionForSitToChair.SetActive(true);
            if (isSit == false)
            {
                sitPosition.transform.position = chair4.transform.position + new Vector3(0.2f, -1.5f, 0);
                Character.transform.rotation = Quaternion.Euler(0, 4f, 0);
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Chair1" || collider.gameObject.tag == "Chair2" || collider.gameObject.tag == "Chair3" || collider.gameObject.tag == "Chair4")
        {
            action = false;
            instructionForSitToChair.SetActive(false);
            
        }
    }
    void SitToChair()
    {
       if(action)
        {
            if (Input.GetKeyDown(KeyCode.E) && isSit)
            {
                isSit = false;
                AnimatorForSit.SetBool("isSat", true);
                ChrMovement.moveTick = false;
                
            }
            else if (Input.GetKeyDown(KeyCode.E) && isSit == false)
            {
               
                AnimatorForSit.SetBool("isSat", false);
                ChrMovement.moveTick = true;
                isSit = true;
                ChrMovement.transform.position = transform.position + new Vector3(0, -0.15f, 0);
            }
        }
    }
}
