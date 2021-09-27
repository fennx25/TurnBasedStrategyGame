using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class MeshBuilderScript : MonoBehaviour
{

    Vector3[] newVertices;
    Vector2[] newUV;
    int[] newTriangles;

    void Start()
    {

    }

    Vector2 scrollPosition;
    private void OnGUI()
    {
        scrollPosition = GUI.BeginScrollView(
            new Rect(0, 0, 220, 1000),
            scrollPosition,
            new Rect(0, 0, 200, opacityPreviewTextures.Length * 210));
        for (int i = 0; i < opacityPreviewTextures.Length; i++)
        {
            GUI.DrawTexture(new Rect(10, i * 210, 200, 200), opacityPreviewTextures[i]);
        }
        GUI.EndScrollView();
    }


    public Single height(DataProc.TerrainDataBlock<Single> t, float width, float height, float x, float y)
    {

        int nRowsCount = t.tContent.GetLength(0);
        int nColumnsCount = t.tContent.GetLength(1);

        float dWidthUnit = ((float)width) / nColumnsCount;
        float dHeightUnit = ((float)height) / nRowsCount;
        newVertices = new Vector3[nRowsCount * nColumnsCount];
        newUV = new Vector2[nRowsCount * nColumnsCount];
        newTriangles = new int[nRowsCount * nColumnsCount * 6];


        Single h = t.tContent[(int)y, (int)x];
        return h;
      
    }

    public void Build(DataProc.TerrainDataBlock<Single> t, float width, float height)
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
                    h / 2,
                    y * dHeightUnit);

                newUV[y * nColumnsCount + x] = new Vector2(
                    (float)x / nColumnsCount,
                    (float)y / nRowsCount);

                if (x < nColumnsCount - 2 && y < nRowsCount - 2)
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

    Texture2D sandOpacity;//8
    Texture2D roadOpacity;//0

    Texture2D[] opacityPreviewTextures;

    public void ApplyTextures(DataProc.TerrainData t)
    {
        roadOpacity = t.nTextureList[11].OpacityTexture();
        sandOpacity = t.nTextureList[8].OpacityTexture();

        Material mat = GetComponent<Renderer>().material;

        mat.SetTexture("_MainTex1", t.nTextureList[3].Texture());
        mat.SetTexture("_OpacityMap1", t.nTextureList[3].OpacityTexture());

        mat.SetTexture("_MainTex2", t.nTextureList[4].Texture());
        mat.SetTexture("_OpacityMap2", t.nTextureList[4].OpacityTexture());

        mat.SetTexture("_MainTex3", t.nTextureList[5].Texture());
        mat.SetTexture("_OpacityMap3", t.nTextureList[5].OpacityTexture());

        mat.SetTexture("_MainTex4", t.nTextureList[6].Texture());
        mat.SetTexture("_OpacityMap4", t.nTextureList[6].OpacityTexture());

        mat.SetTexture("_MainTex5", t.nTextureList[7].Texture());
        mat.SetTexture("_OpacityMap5", t.nTextureList[7].OpacityTexture());

        mat.SetTexture("_MainTex6", t.nTextureList[8].Texture());
        mat.SetTexture("_OpacityMap6", t.nTextureList[8].OpacityTexture());

        mat.SetTexture("_MainTex7", t.nTextureList[11].Texture());
        mat.SetTexture("_OpacityMap7", t.nTextureList[11].OpacityTexture());

        mat.SetTexture("_MainTex7", t.nTextureList[9].Texture());
        mat.SetTexture("_OpacityMap7", t.nTextureList[9].OpacityTexture());
    }

    public void LoadOpacityMapsForPreview(DataProc.TerrainData t) {
        // Opacity
        opacityPreviewTextures = new Texture2D[t.nTextureList.Count];
        String st = "";
        for (int i = 0; i < t.nTextureList.Count; i++)
        {
            opacityPreviewTextures[i] = t.nTextureList[i].OpacityTexture();
            st += "- " + i + "\n";
            st += t.nTextureList[i].stLayerName + "\n";
            st += t.nTextureList[i].stTexturePath + "\n";
        }
        //Debug.Log(st);

    }
}




