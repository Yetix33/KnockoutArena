using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject scoreObject;
    public static bool isGamePaused = false;
    public GameObject PauseMenuUI;
    Score scoreScript;
    void Start() {
        scoreScript = scoreObject.GetComponent<Score>();
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(isGamePaused){
                Resume();
            } else {
                Pause();
            }
        }
    }
    public void Resume () {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    void Pause () {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused= true;
    }
    public void Restart() {
        Time.timeScale = 1f;
        scoreScript.ResetScore();
        SceneManager.LoadScene("scene1");
    }
    public void LoadMenu(){
        Time.timeScale = 1f;
        scoreScript.ResetScore();
        SceneManager.LoadScene("StartMenu");
    }

}
