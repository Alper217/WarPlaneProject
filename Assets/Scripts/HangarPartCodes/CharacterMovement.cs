using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public AudioClip Walk;
    public AudioClip Running;
    public Animator animator;
    public float jumpForce;
    public float speed = 5f;
    public float runSpeed;
    public float countDown = 0f;
    public GameObject CameraMove;
    private Rigidbody rb;
    public bool isJump = false;
    public float gravityModifier =5;
    public bool moveTick = true;
    

    void Start()
    {
        CameraMove = GameObject.Find("Main Camera");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        countDown++;
        if (countDown >250)
        {
            isJump = false;
        }
        CharacterMove();
    }

    void CharacterMove()
    {
        if (moveTick == true)
        {

            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            bool runKey = Input.GetKey(KeyCode.LeftShift);
            if (vertical > 0)
            {
                animator.SetBool("isMoving", true); 
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                CameraRotation();
            }
            else
            {
                animator.SetBool("isMoving", false); // Ýleri hareket animasyonunu durdur
            }

            if (vertical < 0)
            {
                animator.SetBool("isBacking", true);
                transform.Translate(Vector3.back * speed * Time.deltaTime);
                CameraRotation();
            }
            else
            {
                animator.SetBool("isBacking", false);
            }

            if (horizontal > 0)
            {
                animator.SetBool("isRight", true);
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isRight", false);
            }

            if (horizontal < 0)
            {
                animator.SetBool("isLeft", true);
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isLeft", false);
            }

            if (vertical > 0 && runKey)
            {
                animator.SetBool("isRun",true);
                transform.Translate(Vector3.forward*Time.deltaTime*runSpeed);
            }
            else
            {
                animator.SetBool("isRun",false);
            }

            if (Input.GetKeyDown(KeyCode.Space)&& isJump == false&&countDown>250)
            {
                animator.SetBool("isJump",true);
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isJump = true;
                countDown = 0;
            }
            else
            {
                animator.SetBool("isJump", false);
            }
        }
    }

    void CameraRotation()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0; 
        Quaternion cameraRotation = Quaternion.LookRotation(cameraForward);
        Quaternion targetRotation = Quaternion.Euler(0, cameraRotation.eulerAngles.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
    }
}