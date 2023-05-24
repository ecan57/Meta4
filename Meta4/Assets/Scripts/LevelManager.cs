using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //public static LevelManager instance;//singleton pattern kullanýmý respawnplayer için
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject friesPrefab;
    [SerializeField] GameObject door;
    [SerializeField] GameObject runText;

    [SerializeField] Transform playerSpawnPos;

    [Header("Knife Spawner")]
    [SerializeField] GameObject knifePrefab;
    [SerializeField] Vector2 spawnValues;
    [SerializeField] float startSpawn;
    [SerializeField] float minSpawn;
    [SerializeField] float maxSpawn;
    [SerializeField] float startWait;
    public static bool knifeStop;
    private float xSpawn = 10f;

    [Header("Mode Spawn")]
    [SerializeField] float easySpawn;
    [SerializeField] float normalSpawn;
    [SerializeField] float hardSpawn;

    [Header ("Bool")]

    public int count;
    public bool canWin;
    public static bool canMove = true;
    public static int countForWin;

    //private SoundManager soundManager;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerSpawner();
        //soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

    private void Start()
    {
        maxSpawn = HardenedScript.instance.HardenedLevel(maxSpawn, easySpawn, normalSpawn, hardSpawn);

        //FriesSpawner();
        StartCoroutine(SpawnFries());
        StartCoroutine(CreateKnife());

        canMove = true; //arada restratta karakter hareket etmiyor onu önlemek için ekledik
    }

    // Update is called once per frame
    private void Update()
    {
        startSpawn = Random.Range(minSpawn, maxSpawn);
    }

    void PlayerSpawner()
    {
        Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity); //konumunu yani 0,0,0 pozisyonda playerimý oluþtur.
    }

    public void RespawnPlayer()//boþluða düþüp öldüðünde yeniden oluþturuluyor playerýmýz
    {
        Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
    }

    public void FriesSpawner()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-3.6f, 0), 0);
        Instantiate(friesPrefab, spawnPos, Quaternion.identity);
    }

    public IEnumerator CreateKnife()
    {
        yield return new WaitForSeconds(startWait);
        while(!knifeStop)
        {
            Vector2 spawnPos = new Vector2(xSpawn, Random.Range(-spawnValues.y, spawnValues.y));
            Instantiate(knifePrefab, spawnPos, Quaternion.identity);

            SoundManager.instance.PlayWithIndex(9);

            yield return new WaitForSeconds(startSpawn);
        }
    }

    public IEnumerator SpawnFries()
    {
        if (count == countForWin)
        {
            canWin = true;
            door.SetActive(true);
            knifeStop = true;
            runText.SetActive(true);
            //soundManager.RunDoorSound();
            SoundManager.instance.PlayWithIndex(11);
        }
        yield return new WaitForSeconds(1.5f);
        if (count < countForWin)
        {
            FriesSpawner();
        }
    }
    public void FriesSpawnerCourotine()
    {
        StartCoroutine(SpawnFries());
    }
}
