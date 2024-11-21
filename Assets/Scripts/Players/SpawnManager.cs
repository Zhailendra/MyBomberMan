using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int playerNumber = 2;
    public Transform[] spawnPoints;
    public float radius = 1f;
    public LayerMask breakableWallLayer;
    
    public void SetPlayerNumber(int number)
    {
        playerNumber = number;
        DestroyBreakableWallAroundSpawnPoint();
    }

    public void DestroyBreakableWallAroundSpawnPoint()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Collider[] colliders = Physics.OverlapSphere(spawnPoint.position, radius, breakableWallLayer);

            foreach (Collider col in colliders)
            {
                if (col.CompareTag("BreakableWall"))
                {
                    Destroy(col.gameObject);
                }
            }
        }
    }
}

