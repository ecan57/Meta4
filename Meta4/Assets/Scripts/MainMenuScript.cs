using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    private void Update()
    {
        ScoreManagerScript.highScore = PlayerPrefs.GetInt("High Score"); //"ScoreManagerScriptinde "High Score" nas�l yaz�ld�ysa burada da �yle olmal�"
        highScoreText.text = "Your   High   Score  :  " + ScoreManagerScript.highScore.ToString();
    }
    public void Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //gerekli sahneyi y�kler
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
