﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangels;
    public int xSize = 20;
    public int zSize = 20;

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        Create();
        UpdateShape();
    }
   
    void Create()
    {
        vertices = new Vector3[(xSize+1)*(zSize+1)];
        for (int i=0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float yPos = Mathf.PerlinNoise(x * .2f, z * .2f) * 2f;
                vertices[i] = new Vector3(x,yPos,z);
                i++;
            }
        }

        triangels = new int[xSize * zSize * 6];
        int vert = 0;
        int tria = 0;

        for (int x = 0; x < zSize; x++)
        {
            for (int i = 0; i < xSize; i++)
            {
                triangels[tria + 0] = vert + 0;
                triangels[tria + 1] = vert + xSize + 1;
                triangels[tria + 2] = vert + 1;
                triangels[tria + 3] = vert + 1;
                triangels[tria + 4] = vert + xSize + 1;
                triangels[tria + 5] = vert + xSize + 2;
                vert++;
                tria += 6;
            }
            vert++;
        }
       
        
    }
 
    void UpdateShape()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangels;
        mesh.RecalculateNormals();
    }
}