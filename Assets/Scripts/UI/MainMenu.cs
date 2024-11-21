using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int playerNumber;
    
    public void PlayGame()
    {
        PlayerPrefs.SetInt("PlayerNumber", playerNumber);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    
    public void GameMode(int mode)
    {
        playerNumber = mode;
        PlayGame();
    }
    
}
