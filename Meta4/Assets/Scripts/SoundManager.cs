using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landSound;
    [SerializeField] AudioClip deadByEnemySound;
    [SerializeField] AudioClip deadByFallSound;
    [SerializeField] AudioClip attackEnemySound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip runDoorSound;
    //[SerializeField] public AudioClip[] sounds; //bunu sen yap

    //#region Singleton
    public static SoundManager instance;//singleton

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Sahnede Fazla Sound Var");
        }
        else
        {
            instance = this;
        } 
    }
    //#endregion
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void JumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
        Debug.Log("JUMP");
    }
    public void LandSound()
    {
        audioSource.PlayOneShot(landSound);
        Debug.Log("LAND");
    }
    public void DeadByEnemySound()
    {
        audioSource.PlayOneShot(deadByEnemySound);
        Debug.Log("DEAD BY ENEMY");
    }
    public void DeadByFallSound()
    {
        audioSource.PlayOneShot(deadByFallSound);
        Debug.Log("DEAD FELL");
    }
    public void AttackEnemySound()
    {
        audioSource.PlayOneShot(attackEnemySound);
        Debug.Log("ATTACK");
    }
    public void WinSound()
    {
        audioSource.PlayOneShot(winSound);
        Debug.Log("WIN SOUND");
    }
    public void RunDoorSound()
    {
        audioSource.PlayOneShot(runDoorSound);
        Debug.Log("RUN TO DO DOOR SOUND");
    }
}
