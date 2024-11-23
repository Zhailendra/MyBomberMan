using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GlobalStateManager globalManager;
    
    private int playerNumber;
    public Transform[] spawnPoints;
    public GameObject[] playerPrefabs;
    public float radius = 1f;
    public LayerMask breakableWallLayer;

    private List<Transform> shuffledSpawnPoints = new List<Transform>();

    private void Awake()
    {
        globalManager = GetComponent<GlobalStateManager>();
        if (globalManager == null)
        {
            Debug.LogError("GlobalStateManager n'est pas assigné !");
        }
    }

    public void SetPlayerNumber(int number)
    {
        playerNumber = number;

        ShuffleSpawnPoints();

        DestroyBreakableWallAroundSpawnPoint();
        SpawnPlayers();
    }

    private void ShuffleSpawnPoints()
    {
        shuffledSpawnPoints.Clear();
        shuffledSpawnPoints.AddRange(spawnPoints);

        System.Random rng = new System.Random();
        int n = shuffledSpawnPoints.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Transform value = shuffledSpawnPoints[k];
            shuffledSpawnPoints[k] = shuffledSpawnPoints[n];
            shuffledSpawnPoints[n] = value;
        }
    }

    public void DestroyBreakableWallAroundSpawnPoint()
    {
        for (int i = 0; i < playerNumber; i++)
        {
            if (i < shuffledSpawnPoints.Count)
            {
                Transform spawnPoint = shuffledSpawnPoints[i];

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

    public void SpawnPlayers()
    {
        for (int i = 0; i < playerNumber; i++)
        {
            if (i < shuffledSpawnPoints.Count)
            {
                Transform spawnPoint = shuffledSpawnPoints[i];

                GameObject player = Instantiate(playerPrefabs[i], spawnPoint.position, Quaternion.identity);

                Player playerScript = player.GetComponent<Player>();
                if (playerScript != null)
                {
                    if (globalManager == null)
                    {
                        Debug.LogError("GlobalStateManager n'est pas assigné aux Players !");
                    }
                    playerScript.SetGlobalStateManager(globalManager);
                }

                BoxCollider boxCollider = spawnPoint.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
            }
        }
    }
}
