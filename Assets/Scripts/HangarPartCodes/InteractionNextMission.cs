using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionNextMission : MonoBehaviour
{
    [SerializeField] GameObject instructionFornNextMission;
    private void Start()
    {
        instructionFornNextMission.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            instructionFornNextMission.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            instructionFornNextMission.SetActive(false);
        }
    }
}
