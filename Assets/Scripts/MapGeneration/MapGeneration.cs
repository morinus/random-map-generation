using UnityEngine;


namespace Smorb.ProceduralGeneration
{
    public class MapGeneration : MonoBehaviour
    {

        [SerializeField] private int mapWidthInTiles;
        [SerializeField] private int mapDepthInTiles;

        [SerializeField] private Transform worldTransform;
        [SerializeField] private GameObject tilePrefab;

        public int MapWidthInTiles { get => mapWidthInTiles; }
        public int MapDepthInTiles { get => mapDepthInTiles; }


        private void Start()
        {
            GenerateMap();
        }

        public void GenerateMap()
        {
            var tileSize = tilePrefab.GetComponent<MeshRenderer>().bounds.size;
            var tileWidth = (int)tileSize.x;
            var tileDepth = (int)tileSize.z;

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
