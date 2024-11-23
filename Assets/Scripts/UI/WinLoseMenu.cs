using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLoseMenu : MonoBehaviour
{
    public void OnEnable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    
    public void Restart()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void Resume()
    {
        Debug.Log("Resume");
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (transform.parent != null)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
    public void ShowMenu(string message)
    {
        Debug.Log("ShowMenu");
        Time.timeScale = 0f;
        GameObject resumeButton = transform.Find("Resume Button").gameObject;

        TextMeshProUGUI textComponent = transform.Find("Text").GetComponent<TextMeshProUGUI>();

        if (message == "SimpleMenu")
        {
            if (transform.parent != null)
            {
                transform.parent.gameObject.SetActive(true);
                textComponent.text = "";
            }

            resumeButton.SetActive(true);
        }
        else
        {
            textComponent.text = message;

            if (transform.parent != null)
            {
                transform.parent.gameObject.SetActive(true);
            }

            resumeButton.SetActive(false);
        }
    }

}
