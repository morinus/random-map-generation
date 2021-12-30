using Smorb.ProceduralGeneration;
using UnityEngine;

namespace Smorb.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private SpawnController spawnController;
        [SerializeField] private MapGeneration mapGeneration;

        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject buttonPrefab;


        private void Start()
        {
            mapGeneration.GenerateMap();

            spawnController.SpawnObjectToRandomLocation(buttonPrefab);
            spawnController.SpawnObjectToRandomLocation(playerPrefab);
        }
    }
}
