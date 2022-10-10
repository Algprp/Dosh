using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject FoodPrefab;
    public Transform spawnPosition;
    public float x,z = 0;
    public Vector3 StartZ,FinishZ;
    public Vector3 LeftX,RightX;
    public int FoodQuantity = 0;
    public int FoodQuantityEnough = 30;


    void Start()
    {
        do
        {
            ++FoodQuantity;
            z = Random.Range(StartZ.x, FinishZ.x);
            x = Random.Range(LeftX.z, RightX.z);
            spawnPosition.position = new Vector3(x, 0.1f, z);
            Instantiate(FoodPrefab, spawnPosition.position, spawnPosition.rotation);
        }
        while (FoodQuantity != FoodQuantityEnough);
    }
}
