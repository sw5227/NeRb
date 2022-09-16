using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[ ] gesturePrefabs;
    private float spawnPosY = 2;
    private float startDelay = 2.5f;
    private float spawnInterval = 1f;
    private float[] spawnPosX = {-1.5f, -0.5f, 0.5f, 1.5f};



    public void StartSpawning()
    {
        InvokeRepeating("SpawnRandomLane", startDelay, spawnInterval);
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnRandomLane");
    }

    void SpawnRandomLane() 
    {

        Vector3 spawnPos = new Vector3(spawnPosX[Random.Range(0, spawnPosX.Length)], spawnPosY, 1 );
        int gestureIndex = Random.Range(0, gesturePrefabs.Length);

        Instantiate(gesturePrefabs[gestureIndex], spawnPos,
        gesturePrefabs[gestureIndex].transform.rotation);
    }

}
