using UnityEngine;

public class FriesScript : MonoBehaviour
{
    LevelManager levelManager;

    private int friesValue;//her obje kendi içinde tutsun diye kendi scriptinde tanýmladýk //=5  5 er puan artarak devam eder. rastgele puan için startta verdik
    
    private void Awake()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
    }
    
    private void Start()
    {
        friesValue = Random.Range(1, 10); //1 ile 10 arasýnda rastgele puan veriyor
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelManager.count++;
            ScoreManagerScript.instance.AddPoint(friesValue);
            levelManager.FriesSpawnerCourotine();
            Destroy(gameObject);
            //levelManager.FriesSpawner();
        }

    }
}
