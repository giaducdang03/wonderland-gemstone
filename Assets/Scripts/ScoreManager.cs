using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text txtScore; 
    public Text txtHighScore; 

    int score; 
    int highscore = 0; 

    void Start()
    {
        // check scence
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 1) 
        {
            highscore = PlayerPrefs.GetInt("highscore", 0);
            score = 0;
            txtScore.text = "SCORE: " + score; // display the initial score
            txtHighScore.text = "HIGH SCORE: " + highscore.ToString(); // display the initial high score
        }
        else
        {
            highscore = PlayerPrefs.GetInt("highscore", 0);
            var scoreLevel1 = PlayerPrefs.GetInt("scoreLevel1", 0);
            score = scoreLevel1;
            txtScore.text = "SCORE: " + score; 
            txtHighScore.text = "HIGH SCORE: " + highscore.ToString(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D Diamond)
    {
        if (Diamond.tag == "Diamond")
        {
            score += 1;
            Destroy(Diamond.gameObject);
            txtScore.text = "SCORE: " + score; // display the initial score new game
            if (highscore < score)
                PlayerPrefs.SetInt("highscore", score);
        }
    }

    public void SetScoreLevel1()
    {
        PlayerPrefs.SetInt("scoreLevel1", score);
    }

}
