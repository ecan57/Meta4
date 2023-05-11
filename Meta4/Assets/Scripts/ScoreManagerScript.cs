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
    
    public static int score; //=0 verilebilir
    public static int highScore; //=0 verilebilir

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score \n " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPoint(int value)
    {
        score += value;
        scoreText.text = "Score \n " + score.ToString();
    }
}
