using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonsScript : MonoBehaviour {

    public Button stopButton;
    public bool isMenuOpen;
    public GameObject panel;

    public void HomeButton()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void PauseButton()
    {
        Time.timeScale = 0;

    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
    }
 
    public void SettingsButton(Button button)
    {
        if(panel.activeSelf)
        {
            return;
        }
        if (button.IsActive())
        {
            button.gameObject.SetActive(false);
            stopButton.gameObject.SetActive(false);
        } else
        {
            stopButton.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
        }
    }

    public void PlayAgainButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

}
