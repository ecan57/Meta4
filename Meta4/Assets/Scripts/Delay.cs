using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] float delayTimer; //unity �zerinde istedi�imiz zaman� verebilmek i�in ekledik
    public bool delayTime = true;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GetComponent<LevelManager>(); //Find eklememize gerek yok ��nk� ayn� obje i�erisindeki script ikisi de
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
    public void StartDelayTime()
    {
        StartCoroutine(DelayNewTime()); //bu fonksiyonun kendisini direk �a�iramad���m�z i�in IEnumeratorden dolay�, yeni bir fonksiyon olu�turup �yle �a��r�yoruz
    }
    IEnumerator DelayNewTime()
    {
        yield return new WaitForSeconds(delayTimer);
        levelManager.RespawnPlayer();
    }
}
