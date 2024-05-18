using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNPC : MonoBehaviour
{
    [SerializeField] GameObject instructionForNPC;
    [SerializeField] GameObject Dialogue;
    private void Start()
    {
        instructionForNPC.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name =="Player")
        {
            instructionForNPC.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Dialogue.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            instructionForNPC.SetActive(false);
            Dialogue.SetActive(false);
        }
    }
}
