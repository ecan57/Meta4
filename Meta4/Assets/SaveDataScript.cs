using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataScript : MonoBehaviour
{
    [SerializeField] TMP_InputField textBox;
    [SerializeField] TextMeshProUGUI infoText;
    public void Save()
    {
       PlayerPrefs.SetString("Name", textBox.text);
        infoText.text = "Your Data Saved.";
    }
    public void Next()
    {
        SceneManager.LoadScene(1);
    }
    public void Default()
    {
        PlayerPrefs.DeleteAll(); //kaydettiðin herþeyi siler playerprefsteki
    }
}
