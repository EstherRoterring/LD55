using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenenWechsel : MonoBehaviour
{
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

    public void NextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToStandardDeathScreen(){
        SceneManager.LoadScene("StandardDeath");
    }
}
