using System.Collections;
using UnityEngine;

public class WheelsUpDown : MonoBehaviour
{
    public GameObject FrontWheel;
    public GameObject BackWheel;
    public Vector3 startPosition; 
    public Vector3 endPosition;
    public float duration = 2f; 
    private bool isWheelUp = false; 

    private void Start()
    {
        startPosition = FrontWheel.transform.position;
        endPosition = BackWheel.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (isWheelUp)
            {
                StartCoroutine(LerpToPosition(transform, startPosition, duration)); 
                isWheelUp = false;
            }
            else
            {
                StartCoroutine(LerpToPosition(transform, endPosition, duration));
                isWheelUp = true;
            }
        }
    }

    IEnumerator LerpToPosition(Transform target, Vector3 targetPosition, float duration)
    {
        Vector3 initialPosition = target.position; // Baþlangýç konumu
        float elapsedTime = 0f; 

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime; 
            float t = elapsedTime / duration; 
            target.position = Vector3.Lerp(initialPosition, targetPosition, t);
            yield return null; 
        }

        target.position = targetPosition; 
        //if (target.position == targetPosition)
        //{

        //}
    }
}
