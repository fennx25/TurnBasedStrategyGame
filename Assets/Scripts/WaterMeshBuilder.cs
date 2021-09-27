using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMeshBuilder : MonoBehaviour
{
    Vector3[] newVertices;
    Vector2[] newUV;
    int[] newTriangles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Build(DataProc.TerrainDataBlock<Byte> t, float width, float height)
    {
        int x, y;
        int nRowsCount = t.tContent.GetLength(0);
        int nColumnsCount = t.tContent.GetLength(1);

        float dWidthUnit = ((float)width) / nColumnsCount;
        float dHeightUnit = ((float)height) / nRowsCount;
        newVertices = new Vector3[nRowsCount * nColumnsCount];
        newUV = new Vector2[nRowsCount * nColumnsCount];
        newTriangles = new int[nRowsCount * nColumnsCount * 6];

        int ti = 0;
        for (y = 0; y < nRowsCount; y++)
        {
            for (x = 0; x < nColumnsCount - 1; x++)
            {
                Single h = t.tContent[y, x];

                newVertices[y * nColumnsCount + x] = new Vector3(
                    x * dWidthUnit,
                    3,
                    y * dHeightUnit);

                newUV[y * nColumnsCount + x] = new Vector2(
                    (float)x / nColumnsCount,
                    (float)y / nRowsCount);

                if (x < nColumnsCount - 2 && y < nRowsCount - 2 && h > 0)
                {
                    newTriangles[ti++] = y * nColumnsCount + x + 1;
                    newTriangles[ti++] = y * nColumnsCount + x + 0;
                    newTriangles[ti++] = y * nColumnsCount + nColumnsCount + x;

                    newTriangles[ti++] = y * nColumnsCount + nColumnsCount + x;
                    newTriangles[ti++] = y * nColumnsCount + nColumnsCount + 1 + x;
                    newTriangles[ti++] = y * nColumnsCount + x + 1;
                }

            }
        }

        Apply();
    }

    void Apply()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();

        // Do some calculations...
        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;
        mesh.RecalculateNormals();
    }
}
