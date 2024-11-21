using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [Range(1, 4)]
    public int playerNumber;
    
    public int nbBombs = 2;
    public int explosionRange = 2;
    public bool unlockedPushableBombs = false;
}
