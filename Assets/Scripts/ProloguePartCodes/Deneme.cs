using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Deneme : MonoBehaviour
{
    [Header("Plane Stats")]
    [Tooltip("How mush the throttle ramps up or down.")]
    public float throttleIncrement = 0.1f;
    [Tooltip("Maximum engine thrust when at 100% throttle.")]
    public float maxThrust = 200f;
    [Tooltip("How responsive the plane is when rolling, pitching and yawing.")]
    [SerializeField]public float responsiveness = 100f;
    private float throttle;
    private float roll;
    private float pitch;
    private float yaw;
    private float responseModifier
    {
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }
    }
    Rigidbody rb;
    [SerializeField] TextMeshProUGUI hud;
    private void Awake()
    {
        rb=GetComponent<Rigidbody>();
    }
    private void HandleInputs()
    {
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");
        if (Input.GetKey(KeyCode.LeftShift)) throttle += throttleIncrement;
        else if(Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;  
        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }
    private void Update()
    {
        HandleInputs();
        UpdateHud();
    }
    private void FixedUpdate()
    {
        // Forward itme gücü, ama ayrýca yerçekimi dikkate alýndýðýnda
        rb.AddForce(transform.forward * maxThrust * throttle);

        // Dengeleyici bir etki ekleyin, örneðin uçaðýn baþý aþaðýdayken yerçekimi ve sürüklenme etkilerini düþünmek
        float gravityEffect = 100.0f; // Gerekirse bu deðerle oynayabilirsiniz
        rb.AddForce(Vector3.down * gravityEffect);

        rb.AddTorque(transform.up * roll * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(transform.forward * yaw * responseModifier);
    }
    private void UpdateHud()
    {
        hud.text = "Throttle: " + throttle.ToString("F0") + "%\n";
        hud.text += "Airspeed: " + (rb.velocity.magnitude * 3.6f).ToString("F0") + "kmh/h\n";
        hud.text += "Altitude: " + transform.position.y.ToString("F0") + "m";
    }
}
