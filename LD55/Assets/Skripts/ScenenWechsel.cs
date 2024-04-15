using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class ScenenWechsel : MonoBehaviour
{

    public static bool GameModeIsHard;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            ResetScene();
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void GoToLvl1()
    {
        PlayerStats.CurrentMana = PlayerStats.MaxMana;
        PlayerStats.fillMana();
        SceneManager.LoadScene("Lvl1");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ResetScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartLvl()
    {
        if (GameModeIsHard)
        {
            GoToLvl1();
        }
        else
        {
            PlayerStats.CurrentMana = PlayerStats.manaLevels[PlayerController.restartPoint];
            SceneManager.LoadScene(PlayerController.restartPoint);
        }

        //PlayerStats.CurrentMana = PlayerStats.MaxMana;
    }

    public static void NextScene()
    {

        int activeScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(PlayerStats.manaLevels[0]);
        PlayerStats.manaLevels[activeScene] = PlayerStats.CurrentMana;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextSceneNormal()
    {
        GameModeIsHard = false;
        PlayerStats.fillMana();
        NextScene();
    }

    public void NextSceneHard()
    {
        GameModeIsHard = true;
        PlayerStats.fillMana();
        NextScene();
    }

    public void GoToStandardDeathScreen()
    {
        SceneManager.LoadScene("StandardDeath");
    }

}
