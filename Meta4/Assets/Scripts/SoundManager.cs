using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    //[SerializeField] AudioClip jumpSound;
    //[SerializeField] AudioClip landSound;
    //[SerializeField] AudioClip deadByEnemySound;
    //[SerializeField] AudioClip deadByFallSound;
    //[SerializeField] AudioClip attackEnemySound;
    //[SerializeField] AudioClip winSound;
    //[SerializeField] AudioClip runDoorSound;
    public AudioClip[] sounds; //bunu sen yap

    #region Singleton
    public static SoundManager instance;//singleton

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //public void PlayAudio(AudioClip clip)
    //{
    //    audioSource.PlayOneShot(clip);
    //} //k�sa y�ntem i�in ikinci se�enek alttaki en iyi se�enek
    
    public void PlayWithIndex(int index)
    {
        audioSource.PlayOneShot(sounds[index]);
        //Debug.Log(index + ". index �al�yor");
    }


    //public void JumpSound()
    //{
    //    audioSource.PlayOneShot(jumpSound);
    //    Debug.Log("JUMP");
    //}
    //public void LandSound()
    //{
    //    audioSource.PlayOneShot(landSound);
    //    Debug.Log("LAND");
    //}
    //public void DeadByEnemySound()
    //{
    //    audioSource.PlayOneShot(deadByEnemySound);
    //    Debug.Log("DEAD BY ENEMY");
    //}
    //public void DeadByFallSound()
    //{
    //    audioSource.PlayOneShot(deadByFallSound);
    //    Debug.Log("DEAD FELL");
    //}
    //public void AttackEnemySound()
    //{
    //    audioSource.PlayOneShot(attackEnemySound);
    //    Debug.Log("ATTACK");
    //}
    //public void WinSound()
    //{
    //    audioSource.PlayOneShot(winSound);
    //    Debug.Log("WIN SOUND");
    //}
    //public void RunDoorSound()
    //{
    //    audioSource.PlayOneShot(runDoorSound);
    //    Debug.Log("RUN TO DO DOOR SOUND");
    //}
}
