using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;

    void Start()
    {
        powerUpPrefab = (GameObject) Resources.Load("PowerUp",typeof(GameObject));
        if (powerUpPrefab == null)
        {
            Debug.LogError("Le prefab PowerUp n'a pas été trouvé dans le dossier Resources !");
        }
    }

    public void SpawnPowerUpRandomly()
    {
        if (Random.Range(0.0f, 1.0f) > 0.7f)
        {
            if (!Physics.CheckSphere(transform.position, 0.5f, LayerMask.GetMask("PowerUp")))
            {
                Debug.Log("SpawnPowerUp");
                Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("Power-up already exists at this location.");
            }
        }
    }
    
}
