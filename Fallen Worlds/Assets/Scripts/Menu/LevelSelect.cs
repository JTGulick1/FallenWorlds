using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour
{
    public TMPro.TMP_Dropdown levelSelect;

    public string MagicalForrest;
    public string ForgottenForrest;

    private PlayerInfoManager playerInfo;

    private void Start()
    {
        playerInfo = PlayerInfoManager.Instance;
    }
    public void StartLevel()
    {
        if (levelSelect.options[levelSelect.value].text == "Magical Forrest")
        {
            SceneManager.LoadScene(MagicalForrest);
        }
        if (levelSelect.options[levelSelect.value].text == "Forgotten Forrest")
        {
            SceneManager.LoadScene(ForgottenForrest);
        }


        playerInfo.inGameTick = true;
        playerInfo.timer = 0.0f;
    }
}
