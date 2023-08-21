using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour
{
    public TMPro.TMP_Dropdown levelSelect;

    public string levelName;

    private PlayerInfoManager playerInfo;

    private void Start()
    {
        playerInfo = PlayerInfoManager.Instance;
    }
    public void StartLevel() // when the player presses start lay the level that is selected
    {
        levelName = levelSelect.options[levelSelect.value].text;

        if (levelSelect.options[levelSelect.value].text == levelName)
        {
            SceneManager.LoadScene(levelName);
        }


        playerInfo.inGameTick = true;
        playerInfo.timer = 0.0f;
    }
}
