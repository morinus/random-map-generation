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
        [SerializeField] private GameObject[] tilePrefabs;


        private void Start()
        {
            InitGame();
        }

        private void InitGame()
        {
            var randomTilePrefab = tilePrefabs[Random.Range(0, tilePrefabs.Length)];

            mapGeneration.GenerateMap(randomTilePrefab);
            Invoke(nameof(StartGame), 0.1f);
            HideCursor();
        }

        private void HideCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void StartGame()
        {
            spawnController.SpawnObjectToRandomLocation(buttonPrefab);
            spawnController.SpawnObjectToRandomLocation(playerPrefab);
        }
    }
}
