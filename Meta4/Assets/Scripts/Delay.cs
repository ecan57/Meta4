using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] float delayTimer; //unity üzerinde istediðimiz zamaný verebilmek için ekledik
    public bool delayTime = true;

    #region Singleton
    public static Delay instance;//singleton

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
        levelManager = GetComponent<LevelManager>(); //Find eklememize gerek yok çünkü ayný obje içerisindeki script ikisi de
    }

    public void StartDelayTime()
    {
        StartCoroutine(DelayNewTime()); //bu fonksiyonun kendisini direk çaðiramadýðýmýz için IEnumeratorden dolayý, yeni bir fonksiyon oluþturup öyle çaðýrýyoruz
    }
    IEnumerator DelayNewTime()
    {
        yield return new WaitForSeconds(delayTimer);
        levelManager.RespawnPlayer();
    }
}
