using UnityEngine;

namespace Smorb.Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuCanvas;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetActiveMainMenuCanvas(!mainMenuCanvas.activeSelf);

                Cursor.lockState = mainMenuCanvas.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
                Cursor.visible = mainMenuCanvas.activeSelf;
            }
        }

        private void SetActiveMainMenuCanvas(bool isActive)
        {
            mainMenuCanvas.SetActive(isActive);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}

