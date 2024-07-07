using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text txtScore; // Reference to the UI text element for displaying the score
    public Text txtHighScore; // Reference to the UI text element for displaying the high score

    int score; // The current score value
    int highscore = 0; // The high score value

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        score = 0;
        txtScore.text = "SCORE: " + score; // Display the initial score
        txtHighScore.text = "HIGH SCORE: " + highscore.ToString(); // Display the initial high score
    }

    private void OnTriggerEnter2D(Collider2D Diamond)
    {
        if (Diamond.tag == "Diamond")
        {
            score += 1;
            Destroy(Diamond.gameObject);
            txtScore.text = "SCORE: " + score; // Display the initial score
            if (highscore < score)
                PlayerPrefs.SetInt("highscore", score);
        }
    }
}
