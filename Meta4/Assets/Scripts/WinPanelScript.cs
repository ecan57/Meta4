using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinPanelScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = "Score : " + ScoreManagerScript.score.ToString();
    }

    public void NextLevel() //ismi restrtt� de�i�tirdik
    {
        int scorePoints = ScoreManagerScript.score;
        LevelManager.countForWin++; //next levele her ge�i�imizde birer birer frieslar artacak
        scoreText.text = scorePoints.ToString();

        SceneManager.LoadScene(1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        LevelManager.canMove = true;
        LevelManager.knifeStop = false;
    }

    public void Quit()
    {
        Application.Quit();
        //Debug.Log("Oyundan ��kt�");
    }
}
