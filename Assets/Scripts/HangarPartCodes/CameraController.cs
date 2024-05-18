using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform followCharacter;
    [SerializeField] private float distance = 5;
    [SerializeField] private float minVerticalAngle = -45;
    [SerializeField] private float maxVerticalAngle = 45;
    [SerializeField] private Vector2 framingOffset;
    private float rotationY;
    float rotationX;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
       FollowPlayerRotation();
    }
    void FollowPlayerRotation()
    {
        rotationX += Input.GetAxis("Mouse Y");
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);
        rotationY += Input.GetAxis("Mouse X");
        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);
        var focusPosition = followCharacter.position + new Vector3(framingOffset.x, framingOffset.y);
        transform.position = focusPosition - targetRotation * new Vector3(0, 0, distance);
        transform.rotation = targetRotation;
    }
}
