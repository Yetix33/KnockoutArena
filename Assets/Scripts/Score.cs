using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform p1;
    public Transform p2;
    public Text p1_scoreText;
    public Text p2_scoreText;
    public static float p1_score;
    public static float p2_score;
    void Start()
    {
   
        p1_scoreText.text = "Player 1: " + p1_score + " Knocks";
        p2_scoreText.text = "Player 2: " + p2_score + " Knocks";

    }

    void Update()
    {
        if(p1.position.y < -5 || p2.position.y < -5){
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
        }
        if(p1.position.y < -10){
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            p2_score += 1;
            p2_scoreText.text = "Player 2: " + p2_score + " Knocks";
            int nextScene = Random.Range(1,10);
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single);

        }
        if(p2.position.y < -10){
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            p1_score += 1;
            p1_scoreText.text = "Player 1: " + p1_score + " Knocks";
            int nextScene = Random.Range(1,10);
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single);

        }
    }

    public void ResetScore(){
        p1_score = 0;
        p2_score = 0;
    }
}
