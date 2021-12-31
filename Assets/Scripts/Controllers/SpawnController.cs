using Smorb.ProceduralGeneration;
using UnityEngine;

namespace Smorb.Controllers
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private Transform worldTransform;
        [SerializeField] private MapGeneration mapGeneration;


        public void SpawnObjectToRandomLocation(GameObject prefab)
        {
            var randomPositionX = Random.Range(Consts.TILE_SIZE, mapGeneration.MapDepthInTiles * Consts.TILE_SIZE - Consts.TILE_SIZE);
            var randomPositionZ = Random.Range(Consts.TILE_SIZE, mapGeneration.MapWidthInTiles * Consts.TILE_SIZE - Consts.TILE_SIZE);
            var randomPosition = new Vector3(randomPositionX, Consts.MAX_HEIGHT, randomPositionZ);

            var spawnObj = Instantiate(prefab, randomPosition, Quaternion.identity, worldTransform);

            RaycastHit hit;
            if (Physics.Raycast(randomPosition, -Vector3.up, out hit))
            {
                float distanceToGround = hit.distance;
                if (hit.transform.CompareTag("Ground"))
                {
                    spawnObj.transform.position = new Vector3(spawnObj.transform.position.x,
                                                            spawnObj.transform.position.y - distanceToGround + Consts.SPAWN_OFFSET_Y,
                                                            spawnObj.transform.position.z);
                }
            }
        }
    }
}
