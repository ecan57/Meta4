using TMPro;
using UnityEngine;

public class ScoreManagerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    public static int score; //=0 verilebilir
    public static int highScore; //=0 verilebilir

    #region Singleton

    public static ScoreManagerScript instance;

    private void Awake()
    {
        if(instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void AddPoint(int value)
    {
        score += value;
        scoreText.text = "Score : " + score.ToString();

        if(highScore < score)
            PlayerPrefs.SetInt("High Score", score); //SEtInt deðiþkenlerimiz int olduðu için kullanýyoruz //eðer highcore scoredan küçükse score u "High Score" yap
    }
}
