using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] float duration; //ne kadar s�rede dolaca�� imagein 
    [SerializeField] Image cooldownImage; 
    // Start is called before the first frame update
    void Start()
    {
        cooldownImage.fillAmount = 0f; //ba�lang��ta s�f�r olarak ba�las��n
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }
    void Timer()
    {
        if(Movement.dashed) //dashed true ise
        {
            duration -= Time.deltaTime; //duration ve cooldown e�it olmal�, belirlenen oranda azaltmaya ba�la dedik
            cooldownImage.fillAmount = Mathf.InverseLerp(2.5f, 0f, duration); // Burada imagi 2.5ften 0a do�ru duration oran�nda doldurmaya art�rmaya ba�la

        }
        else
        {
            cooldownImage.fillAmount = 0f;
            duration = 2.5f;
        }
    }
}
