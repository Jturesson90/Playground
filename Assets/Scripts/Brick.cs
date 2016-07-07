using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(MeshRenderer), typeof(Mesh), typeof(MeshFilter))]
public class Brick : MonoBehaviour
{
    MeshFilter meshFilter;
    Mesh mesh;
    MeshRenderer meshRenderer;
    public Size BrickSize;
    public bool ComingFromRight = false;

    List<int> triangles;
    List<Vector3> vertices;
    Cube cube;
    void Awake()
    {
        
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        vertices = new List<Vector3>();
    }

    // Use this for initialization
    void Start()
    {
        GenerateCube();
    }

    // Update is called once per frame
    void Update()
    {

    }
    [System.Serializable]
    public struct Size
    {
        public float Width;
        public float Length;
        public float Height;

        public Size(float height, float length, float width)
        {
            Length = length;
            Width = width;
            Height = height;
        }

    }


    void GenerateCube()
    {
        var size = BrickSize;
        mesh.Clear();

        cube = new Cube(size.Width, size.Height, size.Length);
        mesh.vertices = cube.Vertices.ToArray();
        mesh.normals = cube.Normals.ToArray();
        mesh.uv = cube.Uvs.ToArray();
        mesh.triangles = cube.Triangles.ToArray();

        mesh.RecalculateBounds();
        mesh.Optimize();


    }

    public void CutCube(Cube otherCube)
    {
        if (cube == null) return;

        if (cube.TopCorners.BottomLeft.x == otherCube.TopCorners.BottomLeft.x)
        {

        }


    }

    public bool IsInside(Brick otherBrick)
    {
        Cube otherCube = otherBrick.cube;

        if (ComingFromRight)
        {
            if (cube.TopCorners.BottomLeft.x > otherCube.TopCorners.BottomLeft.x &&
                cube.TopCorners.BottomLeft.x < otherCube.TopCorners.BottomRight.x  

                )
            {

            }
        }
        else
        {
            if (cube.TopCorners.BottomLeft.x < otherCube.TopCorners.BottomLeft.x &&
                cube.TopCorners.BottomLeft.x > otherCube.TopCorners.TopLeft.x)
            {
                
            }
        }
        
        return true;
    }


}
