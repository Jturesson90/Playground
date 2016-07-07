using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BrickSpawner : MonoBehaviour
{

    public float cubeYSize = 0.2f;
    public float cubeXZSize = 3f;
    float y = 0f;
    List<GameObject> bricks;
    // Use this for initialization
    void Start()
    {
        bricks = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnBrick();
        }
    }

    private void SpawnBrick()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        if (bricks.Count > 0)
        {
            var brick = bricks[bricks.Count - 1];
            cube.transform.localScale = new Vector3(brick.transform.localScale.x, cubeYSize, brick.transform.localScale.z);
        }
        else
        {
            cube.transform.localScale = new Vector3(cubeXZSize, cubeYSize, cubeXZSize);
        }
        cube.transform.position = new Vector3(0, y, 0);
        bricks.Add(cube);
        cube.transform.parent = gameObject.transform;


        y += cubeYSize;

        var lastBrick = bricks[bricks.Count - 1];
        lastBrick.transform.localScale *= 0.95f;
        CameraSmoother.target = cube.transform;


    }
}
