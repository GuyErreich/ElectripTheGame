using UnityEngine;
using System.Collections;

public class PaintTerrain : MonoBehaviour {
    
    [System.Serializable]
    public class SplatHeights{
        public int textureIndex;
        public float startingHeight;
    }

    public SplatHeights[] splatHeights;

    private void Start() {
        // TerrainData terrainData = Terrain.activeTerrain.terrainData;
        foreach(Terrain terrain in Terrain.activeTerrains)
        {
            TerrainData terrainData = terrain.terrainData;

            float[,,] splatmapData = new float[terrainData.alphamapWidth,
                                                terrainData.alphamapHeight,
                                                terrainData.alphamapLayers];

            for (int z = 0; z < terrainData.alphamapHeight; z++)
            {
                for (int x = 0; x < terrainData.alphamapWidth; x++)
                {
                    float terrainSteepness = Mathf.Abs(terrainData.GetSteepness(x, z));
                    float[] splat = new float[splatHeights.Length];
                    for (int i = 0; i < splatHeights.Length; i++)
                    {
                        if (i == splatHeights.Length - 1 && 
                            terrainSteepness >= splatHeights[i].startingHeight)
                            splat[i] = 1;
                        else if (terrainSteepness <= splatHeights[i + 1].startingHeight)
                            splat[i] = 1;
                    }

                    for (int j = 0; j < splatHeights.Length; j++)
                    {
                        splatmapData[x, z, j] = splat[j];
                    }
                }
            }

            terrainData.SetAlphamaps(0 , 0, splatmapData);
        }
    }
}