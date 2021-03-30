using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public void PlayGame () {
        SceneManager.LoadScene("scene1");
    }
    public void ExitGame () {
        Debug.Log("Quit");
        Application.Quit();
    }

}
