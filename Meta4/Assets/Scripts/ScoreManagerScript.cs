using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagerScript : MonoBehaviour
{
    #region Singleton

    public static ScoreManagerScript instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    
    public static int score; //=0 verilebilir
    public static int highScore; //=0 verilebilir

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPoint(int value)
    {
        score += value;
        scoreText.text = "Score : " + score.ToString();

        if(highScore < score)
        {
            PlayerPrefs.SetInt("High Score", score); //SEtInt deðiþkenlerimiz int olduðu için kullanýyoruz //eðer highcore scoredan küçükse score u "High Score" yap
        }
    }
}
