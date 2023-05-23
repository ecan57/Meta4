using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DificultyManagerScript : MonoBehaviour
{
    //HideInInspector burada public yapmam�z gereken ama unityde inspectorde kalabla�k yapmas�n diye koyuyoruz
    [HideInInspector] public bool easyMode, normalMode, hardMode;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("Easy Mode");
        PlayerPrefs.DeleteKey("Normal Mode");
        PlayerPrefs.DeleteKey("Hard Mode");

        easyMode = false;
        normalMode = false;
        hardMode = false;
    }

    public void EasyMode()
    {
        easyMode = true;
        PlayerPrefs.SetInt("Easy Mode", easyMode ? 1 : 0);
        SceneManager.LoadScene(1);
    }
    public void NormalMode()
    {
        normalMode = true;
        PlayerPrefs.SetInt("Normal Mode", normalMode ? 1 : 0);
        SceneManager.LoadScene(1);
    }
    public void HardMode()
    {
       hardMode = true;
        PlayerPrefs.SetInt("Hard Mode", hardMode ? 1 : 0);
        SceneManager.LoadScene(1);
    }
}