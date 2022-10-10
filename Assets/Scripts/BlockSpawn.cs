using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    public GameObject blockWallSpawn;
    public Transform spawnPosition;
    public float z = 0;
    public float distanceBetweenBlocks = 10f;
    public int blockWallsQuantity = 0;
    public int blockWallsEnough = 10;


    void Start()
    {
        do
        {
            ++blockWallsQuantity;
            z -= distanceBetweenBlocks;
            spawnPosition.position = new Vector3(-5.2f, 0.61f, z);
            Instantiate(blockWallSpawn, spawnPosition.position, spawnPosition.rotation);
        }
        while (blockWallsQuantity != blockWallsEnough);
    }
}
