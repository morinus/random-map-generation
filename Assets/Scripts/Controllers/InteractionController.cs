using UnityEngine;
using UnityEngine.SceneManagement;

namespace Smorb.Controllers
{
    public class InteractionController : MonoBehaviour
    {
        [SerializeField] private GameObject interactUI;

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
            if (other.CompareTag("Finish"))
            {
                SetActiveInteractScreen(true);
                isNextToButton = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Finish"))
            {
                SetActiveInteractScreen(false);
                isNextToButton = false;
            }
        }

        private void SetActiveInteractScreen(bool isActive)
        {
            interactUI.SetActive(isActive);
        }
    }
}
