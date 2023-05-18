using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class WinPanelScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private void Update()
    {
        scoreText.text = "Score : " + ScoreManagerScript.score.ToString();
    }
    public void NextLevel() //ismi restrttý deðiþtirdik
    {
        int scorePoints = ScoreManagerScript.score;
        scoreText.text = scorePoints.ToString();
        SceneManager.LoadScene(1);
        LevelManager.canMove = true;
        LevelManager.knifeStop = false;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Oyundan Çýktý");
    }
}
