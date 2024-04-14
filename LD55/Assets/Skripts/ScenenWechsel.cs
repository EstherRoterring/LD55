using System.Collections;
using System.Collections.Generic;
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

    public void GoToMenu(){
        SceneManager.LoadScene("TitleScreen");
    }

    public void GoToLvl1(){
        SceneManager.LoadScene("Lvl1");
    }

    public void Exit(){
        Application.Quit();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartLvl(){
        if (GameModeIsHard){
            GoToLvl1();
        }
        else{
            SceneManager.LoadScene(PlayerController.restartPoint); 
        }
        
        //PlayerStats.CurrentMana = PlayerStats.MaxMana;
    }

    public void NextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextSceneNormal(){
        GameModeIsHard = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextSceneHard(){
        GameModeIsHard = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToStandardDeathScreen(){
        SceneManager.LoadScene("StandardDeath");
    }
}
