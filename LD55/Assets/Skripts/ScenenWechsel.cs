using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class ScenenWechsel : MonoBehaviour
{

    public static bool GameModeIsHard;

    public static void GoToMenu()
    {
        SceneManager.LoadScene("TitleScreen");
        PlayerStats.fillallMana();
        clockScript.currentTime = 0;
    }

    public static void GoToLvl1()
    {
        PlayerStats.fillallMana();
        PlayerStats.loadMana(1);
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

    public static void ResetScene()
    {
        int thisScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(thisScene);
        PlayerStats.loadMana(thisScene);
    }

    public static void RestartLvl()
    {
        if (ScenenWechsel.GameModeIsHard)
        {
            GoToLvl1();
        }
        else
        {
            Debug.Log("Hehe doch hier unten");
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

    public static void GoToLvl1Normal()
    {
        ScenenWechsel.GameModeIsHard = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public static void GoToLvl1Hard()
    {
        ScenenWechsel.GameModeIsHard = true;
        GoToLvl1();
    }

    public static void GoToStandardDeathScreen()
    {
        SceneManager.LoadScene("StandardDeath");
        clockScript.clockStarted = false;
    }

}
