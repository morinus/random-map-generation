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
            var randomPositionX = Random.Range(1, mapGeneration.MapDepthInTiles * Consts.TILE_SIZE);
            var randomPositionZ = Random.Range(1, mapGeneration.MapWidthInTiles * Consts.TILE_SIZE);
            var randomPosition = new Vector3(randomPositionX, Consts.MAX_HEIGHT, randomPositionZ);

            var player = Instantiate(prefab, randomPosition, Quaternion.identity, worldTransform);

            RaycastHit hit;
            if (Physics.Raycast(randomPosition, -Vector3.up, out hit))
            {
                float distanceToGround = hit.distance;
                if (hit.transform.CompareTag("Ground"))
                {
                    player.transform.position = new Vector3(player.transform.position.x,
                                                            distanceToGround - player.transform.position.y + Consts.SPAWN_OFFSET_Y,
                                                            player.transform.position.z);
                }
            }

            player.transform.Rotate(Vector3.up * Random.Range(0, 360), Space.World);
        }
    }
}
