using UnityEngine;

public class SitToBench : MonoBehaviour
{
    public Rigidbody Player;
    public Transform Character;
    public GameObject Bench;
    public Collider benchCollider;
    public Transform sitPosition;
    public Transform sitRotation;
    public GameObject instructionForSitToBench;
    public Animator AnimatorForSit;
    public bool action;
    public bool isSit;
    private CharacterMovement ChrMovement; // Deðiþkeni burada tanýmlýyoruz

    void Start()
    {
        
        ChrMovement = GetComponent<CharacterMovement>(); // ChrMovement'i baþlatýyoruz
        benchCollider = Bench.GetComponent<Collider>();
        Character = GetComponent<Transform>();
        isSit = true;
        instructionForSitToBench.SetActive(false);
        Character.transform.position = sitPosition.position;
        Character.transform.rotation = sitRotation.rotation;
    }

    void Update()
    {
        PressToSit();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bench")
        {
            action = true;
            instructionForSitToBench.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Bench")
        {
            action = false;
            instructionForSitToBench.SetActive(false);
        }
    }

    void PressToSit()
    {
        if (action == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && isSit)
            {
                benchCollider.isTrigger = true;
                Player.constraints = RigidbodyConstraints.FreezePositionY;
                Player.constraints = RigidbodyConstraints.FreezeAll;
                ChrMovement.moveTick = false;
                AnimatorForSit.SetBool("isSat", true);
                isSit = false;
                sitPosition.transform.position = Bench.transform.position + new Vector3(0.2f, 0, 0);
                Debug.Log("Çalýþtý");
                Character.transform.rotation = Quaternion.Euler(0, 90f, 0);
                

            }
            else if (Input.GetKeyDown(KeyCode.E) && isSit == false)
            {
                AnimatorForSit.SetBool("isSat", false);
                isSit = true;
                ChrMovement.moveTick = true;
                benchCollider.isTrigger = false;
            }
        }
    }
}
