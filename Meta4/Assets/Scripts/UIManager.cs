using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    Canvas canvas;
    private void Start()
    {
        canvas = GetComponent<Canvas>();    
    }
    private void Update()
    {
        scoreText.text = "Your Score : " + ScoreManagerScript.score.ToString();
        ScoreManagerScript.highScore = PlayerPrefs.GetInt("High Score"); //"ScoreManagerScriptinde "High Score" nasýl yazýldýysa burada da öyle olmalý"
        highScoreText.text = "Your High Score : " + ScoreManagerScript.highScore.ToString();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        canvas.enabled = false;
        ScoreManagerScript.score = 0;
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
        ScoreManagerScript.score = 0; //score 0 lamak için yaptýk
    }
}
