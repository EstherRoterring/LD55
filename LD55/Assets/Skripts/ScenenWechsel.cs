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
        PlayerStats.fillMana();
        clockScript.currentTime = 0;
    }

    public void GoToLvl1()
    {
        PlayerStats.fillallMana();
        SceneManager.LoadScene("Lvl1");
        clockScript.currentTime = 0;
    }

    public void Exit()
    {

#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
        Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
#endif
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
        Application.Quit();
#elif (UNITY_WEBGL)
        Application.OpenURL("https://ldjam.com/events/ludum-dare/55/$385543");
        Application.Quit();
#endif
    }

    public void ResetScene()
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        RestartLvl();
    }

    public void RestartLvl()
    {
        if (GameModeIsHard)
        {
            GoToLvl1();
        }
        else
        {

            SceneManager.LoadScene(PlayerController.restartPoint);
            PlayerStats.loadMana(PlayerController.restartPoint);
            Debug.Log(PlayerStats.manaLevels[PlayerController.restartPoint]);
        }

        //PlayerStats.CurrentMana = PlayerStats.MaxMana;
    }

    public static void NextScene()
    {

        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("NextScene scene!!!" + PlayerStats.manaLevels[currentLevel]);
        SceneManager.LoadScene(currentLevel + 1);
        PlayerStats.saveCurrentMana(currentLevel + 1);
    }

    public void GoToLvl1Normal()
    {
        GameModeIsHard = false;
        GoToLvl1();
    }

    public void GoToLvl1Hard()
    {
        GameModeIsHard = true;
        GoToLvl1();
    }

    public void GoToStandardDeathScreen()
    {
        SceneManager.LoadScene("StandardDeath");
        clockScript.clockStarted = false;
    }

}
