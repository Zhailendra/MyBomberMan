using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int playerNumber = 0;

    public void OnEnable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PlayerPrefs.DeleteAll();
    }
    
    private void PlayGame()
    {
        PlayerPrefs.SetInt("PlayerNumber", playerNumber);
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
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
