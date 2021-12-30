using UnityEngine;

namespace Smorb.ProceduralGeneration
{
    public class NoiseMapGeneration : MonoBehaviour
    {
        public float[,] GenerateNoiseMap(int mapDepth, int mapWidth, float scale, float offsetX, float offsetZ, Wave[] waves)
        {
            var noiseMap = new float[mapDepth, mapWidth];

            for (int zIndex = 0; zIndex < mapDepth; ++zIndex)
            {
                for (int xIndex = 0; xIndex < mapWidth; ++xIndex)
                {
                    var sampleX = (xIndex + offsetX) / scale;
                    var sampleZ = (zIndex + offsetZ) / scale;

                    float noise = 0f;
                    float normalization = 0f;
                    foreach (Wave wave in waves)
                    {
                        noise += wave.Amplitude * Mathf.PerlinNoise(sampleX * wave.Frequency + wave.Seed, sampleZ * wave.Frequency + wave.Seed);
                        normalization += wave.Amplitude;
                    }

                    noise /= normalization;

                    noiseMap[zIndex, xIndex] = noise;
                }
            }

            return noiseMap;
        }
    }
}
