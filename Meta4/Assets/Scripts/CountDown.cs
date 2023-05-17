using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] float duration; //ne kadar sürede dolacaðý imagein 
    [SerializeField] Image cooldownImage; 
    // Start is called before the first frame update
    void Start()
    {
        cooldownImage.fillAmount = 0f; //baþlangýçta sýfýr olarak baþlasýýn
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
            duration -= Time.deltaTime; //duration ve cooldown eþit olmalý, belirlenen oranda azaltmaya baþla dedik
            cooldownImage.fillAmount = Mathf.InverseLerp(2.5f, 0f, duration); // Burada imagi 2.5ften 0a doðru duration oranýnda doldurmaya artýrmaya baþla

        }
        else
        {
            cooldownImage.fillAmount = 0f;
            duration = 2.5f;
        }
    }
}
