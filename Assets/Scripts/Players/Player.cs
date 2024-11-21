using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public GlobalStateManager globalManager;
    
    [Range(1, 4)]
    public int playerNumber;
    
    public int nbBombs = 2;
    public int explosionRange = 2;
    public bool unlockedPushableBombs = false;
    public int lives = 1;
    public float moveSpeed = 5f;
    public bool remoteControl = false;
    
    public void SetGlobalStateManager(GlobalStateManager manager)
    {
        Debug.Log ("P" + playerNumber + " got a GlobalStateManager!");
        globalManager = manager;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            lives--;
            Debug.Log ("P" + playerNumber + " hit by explosion!");
            if (lives <= 0)
            {
                Debug.Log ("P" + playerNumber + " is dead!");
                globalManager.PlayerDied(playerNumber);
                Destroy (gameObject);
            }
        }
    }
    
}
