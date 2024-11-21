using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnerManager : MonoBehaviour
{
    public GameObject powerUpGame;

    void Start () {
        powerUpGame = (GameObject) Resources.Load("PowerUp",typeof(GameObject));
    }
}
