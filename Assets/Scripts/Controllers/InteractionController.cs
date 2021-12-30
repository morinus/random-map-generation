using UnityEngine;
using UnityEngine.SceneManagement;

namespace Smorb.Controllers
{
    public class InteractionController : MonoBehaviour
    {
        [SerializeField] private GameObject interactText;

        private bool isNextToButton = false;


        private void Update()
        {
            if (isNextToButton)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    SceneManager.LoadScene("MainScene");
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Button"))
            {
                SetActiveInteractScreen(true);
                isNextToButton = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Button"))
            {
                SetActiveInteractScreen(false);
                isNextToButton = false;
            }
        }

        private void SetActiveInteractScreen(bool isActive)
        {
            interactText.SetActive(isActive);
        }
    }
}
