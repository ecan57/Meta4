using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePositionScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("PositionX") || PlayerPrefs.HasKey("PositionY"))
        {
            player.transform.position = new Vector2(PlayerPrefs.GetFloat("PositionX"), PlayerPrefs.GetFloat("PositionY"));
        }
        else
        {
            player.transform.position = new Vector2(0, 0);
        }
        playerName.text = PlayerPrefs.GetString("Name");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("PositionX", player.transform.position.x);
        PlayerPrefs.SetFloat("PositionY", player.transform.position.y);
        infoText.text = "Data Saved";
    }
    public void Reset()
    {
        PlayerPrefs.DeleteKey("PositionX");
        PlayerPrefs.DeleteKey("PositionY");
        infoText.text = "Data Deleted";
    }
    public void Reload()
    {
        SceneManager.LoadScene(2);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
