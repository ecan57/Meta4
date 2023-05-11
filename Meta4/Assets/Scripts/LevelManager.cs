using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //public static LevelManager instance;//singleton pattern kullanýmý respawnplayer için
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject friesPrefab;
    [SerializeField] GameObject door;
    [SerializeField] GameObject runText;
    [SerializeField] Transform playerSpawnPos;

    public int count;
    public bool canWin;
    public static bool canMove = true;

    private SoundManager soundManager;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerSpawner();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }
    private void Start()
    {
        //FriesSpawner();
        StartCoroutine(SpawnFries());
    }

    // Update is called once per frame
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
    public IEnumerator SpawnFries()
    {
        if (count == 5)
        {
            canWin = true;
            door.SetActive(true);
            runText.SetActive(true);
            soundManager.RunDoorSound();
        }
        yield return new WaitForSeconds(1.5f);
        if (count < 5)
        {
            FriesSpawner();
        }
    }
    public void FriesSpawnerCourotine()
    {
        StartCoroutine(SpawnFries());
    }
}
