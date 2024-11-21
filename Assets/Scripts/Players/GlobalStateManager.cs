using UnityEngine;
using System.Collections;

public class GlobalStateManager : MonoBehaviour
{
    public int playerNumber;
    public SpawnManager spawnManager;

    private int deadPlayers = 0;
    private int deadPlayerNumber = -1;
    private int[] totalPlayers;

    void Start()
    {
        playerNumber = PlayerPrefs.GetInt("PlayerNumber", 0);
        spawnManager = GetComponent<SpawnManager>();

        if (playerNumber == 0)
        {
            Debug.LogError("Player number is not set in PlayerPrefs! Make sure to set it in the main menu.");
        }
        else
        {
            spawnManager.SetPlayerNumber(playerNumber);
            totalPlayers = new int[playerNumber];
        }
    }
    
    private void DestroyExistingPlayers()
    {
        Player[] existingPlayers = FindObjectsOfType<Player>();

        foreach (Player player in existingPlayers)
        {
            if (player != null && player.gameObject != null)
            {
                Destroy(player.gameObject);
                Debug.Log("Ancien joueur détruit.");
            }
        }
    }

    public void PlayerDied(int playerNumber)
    {
        deadPlayers++;

        deadPlayerNumber = playerNumber;

        FindDeadPlayerInList();

        if (deadPlayers == this.playerNumber)
        {
            Invoke("CheckWinner", 0.3f);
        }
    }
    
    private void FindDeadPlayerInList()
    {
        for (int i = 0; i < totalPlayers.Length; i++)
        {
            if (totalPlayers[i] == deadPlayerNumber)
            {
                Debug.Log("Le joueur " + totalPlayers[i] + " est mort.");
                totalPlayers[i] = -1;
            }
        }
    }

    private void CheckWinner()
    {
        for (int i = 0; i < totalPlayers.Length; i++)
        {
            if (totalPlayers[i] != -1)
            {
                Debug.Log("Le joueur " + totalPlayers[i] + " a gagné !");
                return;
            }
        }
        
        Debug.Log("Tout le monde est mort !, Egalité !");
        
    }
}
