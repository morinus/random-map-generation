using UnityEngine;

namespace Smorb.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private SpawnController spawnController;
        [SerializeField] private GameObject playerPrefab;


        private void Start()
        {
            spawnController.SpawnObjectToRandomLocation(playerPrefab);
        }
    }
}
