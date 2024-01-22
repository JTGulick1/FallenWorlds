using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsCanvas : MonoBehaviour
{
    private PlayerController gameManager;
    private AudioSource InGameAudio;
    private AudioSource Music;
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        InGameAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        Music = GameObject.FindGameObjectWithTag("PlayerInfoManager").GetComponent<AudioSource>();
    }
    public void BackToGame()
    {
        gameManager.SettMenu();
    }
    public void LeaveGame()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
