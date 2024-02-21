using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsCanvasMenu : MonoBehaviour
{
    private PlayerControllerMenu gameManager;
    private AudioSource InGameAudio;
    private AudioSource Music;
    public Slider audioS;
    public Slider musicS;
    public Slider Vsen;
    public Slider Hsen;
    private CinemachinePOVEXT pOVEXT;
    public GameObject remappingCanvas;

    private void Update()
    {
        if (gameManager == null)
        {
            gameManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerMenu>();
            InGameAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
            Music = GameObject.FindGameObjectWithTag("PlayerInfoManager").GetComponent<AudioSource>();
            pOVEXT = GameObject.FindGameObjectWithTag("CamHolder").GetComponent<CinemachinePOVEXT>();
        }
        InGameAudio.volume = audioS.value;
        Music.volume = musicS.value;
        pOVEXT.verticalSpeed = Vsen.value * 100;
        pOVEXT.horizontalSpeed = Hsen.value * 100;
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
    public void RemapCanvas()
    {
        remappingCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void SettCanvas()
    {
        remappingCanvas.SetActive(false);
        this.gameObject.SetActive(true);
    }
}
