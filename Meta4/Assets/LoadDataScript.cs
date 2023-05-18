using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadDataScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI loadText;
   
    void Update()
    {
        if (PlayerPrefs.HasKey("Name")) //save olunan isim bulundu mu 
        {
            loadText.text = "Your Name is " + PlayerPrefs.GetString("Name");
        }
        else
        {
            loadText.text = "There is no registered key";
        }
    }
    public void Delete()
    {
        PlayerPrefs.DeleteKey("Name");
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
