using UnityEngine;

namespace Smorb.ProceduralGeneration
{
    public class TileGeneration : MonoBehaviour
    {
        [SerializeField] NoiseMapGeneration noiseMapGeneration;

        [SerializeField] private MeshRenderer tileRenderer;
        [SerializeField] private MeshFilter meshFilter;
        [SerializeField] private MeshCollider meshCollider;

        [SerializeField] private float levelScale;
        [SerializeField] private Terrain[] terrains;
        [SerializeField] private float heightMultiplier;
        [SerializeField] private AnimationCurve heightCurve;
        [SerializeField] private Wave[] waves;


        private void Start()
        {
            GenerateTile();
        }

        private void GenerateTile()
        {
            var meshVertices = meshFilter.mesh.vertices;
            var tileDepth = (int)Mathf.Sqrt(meshVertices.Length);
            var tileWidth = tileDepth;

            var offsetX = -gameObject.transform.position.x;
            var offsetZ = -gameObject.transform.position.z;

            var heightMap = noiseMapGeneration.GenerateNoiseMap(tileDepth, tileWidth, levelScale, offsetX, offsetZ, waves);

            Texture2D tileTexture = BuildTexture(heightMap);
            tileRenderer.material.mainTexture = tileTexture;

            UpdateMeshVertices(heightMap);
        }

        private Texture2D BuildTexture(float[,] heightMap)
        {
            var tileDepth = heightMap.GetLength(0);
            var tileWidth = heightMap.GetLength(1);

            Color[] colorMap = new Color[tileDepth * tileWidth];
            for (int zIndex = 0; zIndex < tileDepth; zIndex++)
            {
                for (int xIndex = 0; xIndex < tileWidth; xIndex++)
                {
                    int colorIndex = zIndex * tileWidth + xIndex;
                    float height = heightMap[zIndex, xIndex];

                    Terrain terrain = ChooseTerrain(height);
                    colorMap[colorIndex] = terrain.Color;
                }
            }

            Texture2D tileTexture = new Texture2D(tileWidth, tileDepth);
            tileTexture.wrapMode = TextureWrapMode.Clamp;
            tileTexture.SetPixels(colorMap);
            tileTexture.Apply();

            return tileTexture;
        }

        Terrain ChooseTerrain(float height)
        {
            foreach (Terrain terrain in terrains)
            {
                if (height < terrain.Height)
                {
                    return terrain;
                }
            }
            return terrains[0];
        }

        private void UpdateMeshVertices(float[,] heightMap)
        {
            var tileDepth = heightMap.GetLength(0);
            var tileWidth = heightMap.GetLength(1);

            Vector3[] meshVertices = meshFilter.mesh.vertices;

            var vertexIndex = 0;
            for (int zIndex = 0; zIndex < tileDepth; zIndex++)
            {
                for (int xIndex = 0; xIndex < tileWidth; xIndex++)
                {
                    float height = heightMap[zIndex, xIndex];

                    Vector3 vertex = meshVertices[vertexIndex];
                    meshVertices[vertexIndex] = new Vector3(vertex.x, this.heightCurve.Evaluate(height) * this.heightMultiplier, vertex.z);

                    vertexIndex++;
                }
            }

            this.meshFilter.mesh.vertices = meshVertices;
            this.meshFilter.mesh.RecalculateBounds();
            this.meshFilter.mesh.RecalculateNormals();
            this.meshCollider.sharedMesh = this.meshFilter.mesh;
        }
    }
}
