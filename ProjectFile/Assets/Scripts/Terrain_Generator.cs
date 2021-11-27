using System;
using UnityEngine;

public class Terrain_Generator : MonoBehaviour
{
    public int depth = 25;
    public int width = 256;
    public int height = 256;
    public float scale = 20f;
    public float xOffset=100f;
    public float yOffset=100f;

    private void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GeneratingTerrain(terrain.terrainData);
    }
    TerrainData GeneratingTerrain(TerrainData terrainDATA)
    {
        //Terrain Piksel Değeri ataması yapıyoruz
        //bu değer 513 ise 512+1 şeklinde olmalıdır.
        terrainDATA.heightmapResolution = width + 1;
        terrainDATA.size = new Vector3(width,depth,height);

        terrainDATA.SetHeights(0,0,GenerateHeights());

        return terrainDATA;
    }

    private float[,] GenerateHeights()
    {
        float[,] heights = new float[width,height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                heights[i, j] = CalculateHeight(i, j);
            }
        }
        return heights;
    }
    float CalculateHeight(int x,int y)
    {
        //Scale Coordinate yoğunluğunu belirtiyor.
    //Offset ise terrain'nde kaydırma işlemi yapmamıza yani pozisyonunu değiştirebiliyoruz
        float xCoord = (float)x / width * scale+xOffset;
        float yCoord = (float)y / height * scale+yOffset;

        return Mathf.PerlinNoise(xCoord,yCoord);
    }
}
