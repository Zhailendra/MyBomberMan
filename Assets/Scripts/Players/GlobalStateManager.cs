using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GlobalStateManager : MonoBehaviour
{
    private SpawnManager spawnManager;
    public WinLoseMenu winLoseMenu;
    public int OriginPlayerNumber = 0;

    public int deadPlayers = 0;
    public List<int> alivePlayers = new List<int>();

    void Start()
    {
        OriginPlayerNumber = PlayerPrefs.GetInt("PlayerNumber");
        SetAlivePlayers();
        spawnManager = GetComponent<SpawnManager>();
        if (spawnManager == null)
        {
            Debug.LogError("SpawnManager n'est pas assigné !");
        }
        else
        {
            spawnManager.SetPlayerNumber(OriginPlayerNumber);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
            {
                winLoseMenu.Resume();
            }
            else
            {
                winLoseMenu.ShowMenu("SimpleMenu");
            }
        }
    }

    public void PlayerDied(int playerNumber)
    {
        deadPlayers++;
        
        alivePlayers.Remove(playerNumber);

        if (alivePlayers.Count <= 1)
        {
            Invoke("CheckWinner", 0.3f);
        }
    }
    
    private void SetAlivePlayers()
    {
        for (int i = 1; i <= OriginPlayerNumber; i++)
        {
            alivePlayers.Add(i);
        }
    }

    private void CheckWinner()
    {
        if (alivePlayers.Count == 0)
        {
            Debug.Log("Tous les joueurs sont morts !");
            winLoseMenu.ShowMenu("Tous les joueurs sont morts !");
        }
        else
        {
            Debug.Log("Le joueur " + alivePlayers[0] + " a gagné !");
            winLoseMenu.ShowMenu("Le joueur " + alivePlayers[0] + " a gagné !");
        }
    }
    
}
