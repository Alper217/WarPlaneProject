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
    [SerializeField] public float responsiveness = 100f;
    private float throttle;
    private float roll;
    private float pitch;
    private float yaw;
    private float responseModifier
    {
        get
        {
            return (rb.mass / 2f) * responsiveness;
        }
    }
    Rigidbody rb;
    [SerializeField] TextMeshProUGUI hud;

    // Yeni sürtünme kuvveti deðiþkeni
    public float dragCoefficient = 0.01f;
    private float minimumThrottle = 0.1f; // Minimum throttle deðeri, motor gücü kesildiðinde bile belirli bir hýzda kalmak için

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void HandleInputs()
    {
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            throttle += throttleIncrement;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            throttle -= throttleIncrement * 0.5f; // throttle deðerini azaltýrken daha küçük bir deðer kullanabiliriz.
        }

        throttle = Mathf.Clamp(throttle, minimumThrottle, 100f);
    }

    private void Update()
    {
        HandleInputs();
        UpdateHud();
    }

    private void FixedUpdate()
    {
        // Forward itme gücü, ama ayrýca yerçekimi dikkate alýndýðýnda
        rb.AddForce(transform.forward * maxThrust * (throttle / 100f));

        // Dengeleyici bir etki ekleyin, örneðin uçaðýn baþý aþaðýdayken yerçekimi ve sürüklenme etkilerini düþünmek
        float gravityEffect = 100.0f; // Gerekirse bu deðerle oynayabilirsiniz
        rb.AddForce(Vector3.down * gravityEffect);

        // Sürtünme kuvveti ekliyoruz
        Vector3 dragForce = -rb.velocity * dragCoefficient * rb.velocity.magnitude;
        rb.AddForce(dragForce);

        rb.AddTorque(transform.up * roll * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(transform.forward * yaw * responseModifier);

        // Hýz azaltma iþlemi
        if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.velocity -= rb.velocity.normalized * 0.5f; 
        }
    }

    private void UpdateHud()
    {
        hud.text = "Throttle: " + throttle.ToString("F0") + "%\n";
        hud.text += "Airspeed: " + ((rb.velocity.magnitude * 3.6f) / 1.5).ToString("F0") + "km/h\n";
        hud.text += "Altitude: " + transform.position.y.ToString("F0") + "m";
    }
}
