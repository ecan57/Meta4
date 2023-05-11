using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float enemyAttackSpeed;
    [SerializeField] float xBoundry; //enemy prefabýnýn içinde enemy scriptinde boundry oluþtu ona platformun sýnýrýný verdik
    [SerializeField] float yBoundry;
    LevelManager levelManager;
    SoundManager soundManager;
    UIManager uiManager;
    Delay delayScript;
    PlayerHealth playerHealth;
    bool isAttacking;

    private void Awake()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        delayScript = GameObject.Find("Level Manager").GetComponent<Delay>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        EnemyDestroyer();
        
    }
    private void FixedUpdate()
    {
        EnemyAttack(); //Fixed update de olduðu için sürekli yeniler
    }
    void EnemyAttack()
    {
        transform.Translate(-1 * enemyAttackSpeed * Time.deltaTime, 0, 0); //delta time belirli bir zaman aralýðý //Time playa basýldýðý anda iþlenen zaman // çok kullanýlýr frame olarak
        //SpriteRenderer baþýndaki tiki kaldýrdýðýmýzda spwnpos görünmüyor
        while (!isAttacking)
        {
            soundManager.AttackEnemySound();
            isAttacking = true; //false olursasonsuz döngüye girer sahne tehliikeye girer . Her deðiþiklikten sonra sahneyi save etmelisin. While gibi döngüler dikkatli kulllanýlmalý
            //burada sadece her obje için bir kere ses verecek
        }
        //soundManager.AttackEnemySound(); //burada yazdýðýmýzda obje hareket ettiði sürece sürekli sesi yeniliyor
    }
    void EnemyDestroyer()
    {
        if (transform.position.x < xBoundry || transform.position.y <yBoundry)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) //dokunduðunda
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            Destroy(collision.gameObject);
            playerHealth.Lives();
            if (delayScript.delayTime == true)
            {
                delayScript.StartDelayTime();
            }
            soundManager.DeadByEnemySound();
            //uiManager.GetComponent<Canvas>().enabled = true; //playerHealt.Lives ekleyince kaldýrdýk
            //levelManager.RespawnPlayer();//enemy çarptýðýnda da tekrar player oluþtur
        }
    }
}
