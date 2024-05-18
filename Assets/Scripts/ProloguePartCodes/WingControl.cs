using UnityEngine;

public class WingControl : MonoBehaviour
{
    public float rotationSpeed = 5f; // Dönme hýzý
    public float maxRotationAngle = 2f; // Maksimum dönme açýsý
    public float minRotationAngle = -2f; // Minimum dönme açýsý
    public GameObject middleWing;
    public GameObject mainWing;
    public GameObject backWing;
    public GameObject plane;

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            RotateWing(-1); 
        }
        else if (Input.GetKey(KeyCode.E))
        {
            RotateWing(1); 
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            RotateMiddleWing(1);
            RotateFrontWing(1);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            RotateMiddleWing(-1);
            RotateFrontWing(-1);
        }
        else
        {
            middleWing.transform.rotation = plane.transform.rotation;
            mainWing.transform.rotation = plane.transform.rotation;
            backWing.transform.rotation = plane.transform.rotation;
            RotateWing(0); 
        }
    }

    void RotateWing(int direction)
    {
        float currentAngle = middleWing.transform.localEulerAngles.y; 
        float targetAngle = Mathf.Clamp(currentAngle + direction * 8f, minRotationAngle, maxRotationAngle); 
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        middleWing.transform.rotation = Quaternion.RotateTowards(middleWing.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void RotateMiddleWing(int direction)
    {
        float currentAngle = mainWing.transform.localEulerAngles.y;
        float targetAngle = Mathf.Clamp(currentAngle + direction * 8f, minRotationAngle, maxRotationAngle);
        Quaternion targetRotation = Quaternion.Euler(targetAngle, plane.transform.localEulerAngles.x, plane.transform.localEulerAngles.z);
        mainWing.transform.rotation = Quaternion.RotateTowards(mainWing.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    void RotateFrontWing(int direction)
    {
        float currentAngle = backWing.transform.localEulerAngles.y;
        float targetAngle = Mathf.Clamp(currentAngle + direction * 8f, minRotationAngle, maxRotationAngle);
        Quaternion targetRotation = Quaternion.Euler(targetAngle, 0,0);
        backWing.transform.rotation = Quaternion.RotateTowards(backWing.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
