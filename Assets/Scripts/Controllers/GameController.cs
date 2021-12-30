using Smorb.ProceduralGeneration;
using UnityEngine;

namespace Smorb.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private SpawnController spawnController;
        [SerializeField] private MapGeneration mapGeneration;
        [SerializeField] private GameObject playerPrefab;


        private void Start()
        {
            mapGeneration.GenerateMap();

            spawnController.SpawnObjectToRandomLocation(playerPrefab);
        }
    }
}
