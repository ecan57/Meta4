using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    Canvas canvas;
    private void Start()
    {
        canvas = GetComponent<Canvas>();    
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        canvas.enabled = false;
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
