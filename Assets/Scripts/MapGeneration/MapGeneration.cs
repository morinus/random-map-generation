using UnityEngine;
using UnityEngine.UI;

namespace Smorb.ProceduralGeneration
{
    public class MapGeneration : MonoBehaviour
    {
        [SerializeField] private Text biomeText;

        [SerializeField] private int mapWidthInTiles;
        [SerializeField] private int mapDepthInTiles;

        [SerializeField] private Transform worldTransform;

        public int MapWidthInTiles { get => mapWidthInTiles; }
        public int MapDepthInTiles { get => mapDepthInTiles; }


        public void GenerateMap(GameObject tilePrefab)
        {
            var tileSize = tilePrefab.GetComponent<MeshRenderer>().bounds.size;
            var tileWidth = (int)tileSize.x;
            var tileDepth = (int)tileSize.z;

            biomeText.text = tilePrefab.name;

            for (int xTileIndex = 0; xTileIndex < MapWidthInTiles; ++xTileIndex)
            {
                for (int zTileIndex = 0; zTileIndex < MapDepthInTiles; ++zTileIndex)
                {
                    var tilePosition = new Vector3(this.gameObject.transform.position.x + xTileIndex * tileWidth,
                        this.gameObject.transform.position.y,
                        this.gameObject.transform.position.z + zTileIndex * tileDepth);

                    var tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity, worldTransform);
                }
            }
        }
    }
}
