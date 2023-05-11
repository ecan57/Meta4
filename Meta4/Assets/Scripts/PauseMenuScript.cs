using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool isPause;
    [SerializeField] GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume() //ppause aktif olunca �al��aacl
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        LevelManager.canMove = true;
        isPause = false;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        LevelManager.canMove = false; //yeri �nemli esc ye bas�nca hareket etmiyor
        Time.timeScale = 0;
        isPause = true;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1; //say�lar oyunun zamna ak���yla ilgili hareketler yava�lar
        LevelManager.canMove = true;
        ScoreManagerScript.score = 0;
    }
}
