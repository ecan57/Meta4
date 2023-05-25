using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    //[SerializeField] GameObject enemy; //çoklu enemy ayný özellikleri karþýlamasý için GameObject[] dizi olarak tanýmlýyoruz MoveEemyde if içinde for ile döngü yazýyoruz
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnPos;
    //[SerializeField] float enemySpeed;

    bool moveEnemy = false;

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if (moveEnemy)
        {
            //enemy.GetComponent<Rigidbody2D>().velocity =  new Vector2 (-1*10, 0); //0.5f verince yukarýya doðruda hareket ediyor, 10 huzun veriyor, -1 x ekseninde geriye doðru
            SpawnEnemy();
            moveEnemy = false;
        }
    }

    void SpawnEnemy()
    {
        //enemy kaldýrdýk spawnpos ekledik onun yerine
        Instantiate(enemyPrefab, spawnPos.position, enemyPrefab.transform.rotation);
        //Instantiate maliyetli bir fonksiyondur dikkatli kullanýlmalý. Sürekli oluþturmak yerine oluþturulan nesneleri yok etmek yerine SetActive kapatýp havuza toplayýp sonra ihtiyaç olunca tekrar kullanýlabilir.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            moveEnemy = true;
        //Debug.Log(collision.gameObject.name + " Objesi giriþ yaptý.");
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log(collision.gameObject.name + " Objesi trigger içinde");
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log(collision.gameObject.name + " Objesi triggerdan çýktý");
    //}
}
