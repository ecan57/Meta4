using UnityEngine;

public class FriesScript : MonoBehaviour
{
    LevelManager levelManager;

    private int friesValue;//her obje kendi i�inde tutsun diye kendi scriptinde tan�mlad�k //=5  5 er puan artarak devam eder. rastgele puan i�in startta verdik
    
    private void Awake()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
    }
    
    private void Start()
    {
        friesValue = Random.Range(1, 10); //1 ile 10 aras�nda rastgele puan veriyor
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
