using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    UIManager uiManager;
    Delay delay;

    [SerializeField] Image[] playerHealthIcons;

    [SerializeField] int playerLifeCount = 3;

    #region Singleton
    public static PlayerHealth instance;//singleton

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("");
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        delay = GameObject.Find("Level Manager").GetComponent<Delay>();
    }

    public void Lives()
    {
        playerLifeCount--;
        Destroy(playerHealthIcons[playerLifeCount]);
        if (playerLifeCount < 1)
        {
            uiManager.GetComponent<Canvas>().enabled = true;
            LevelManager.knifeStop = true;
            delay.delayTime = false;
        }
    }
}
