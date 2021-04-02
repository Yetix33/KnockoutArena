using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public void PlayGame () {
        int nextScene = Random.Range(1,10);
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);

    }
    public void ExitGame () {
        Debug.Log("Quit");
        Application.Quit();
    }

}
