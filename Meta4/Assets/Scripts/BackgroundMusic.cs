using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;

    public static BackgroundMusic instance; //singleton kullanýmý

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); //gameobject dediðimiz background music. Çalýþtýrýnca birden fazla varsa yok et.
            //Debug.Log("Sahnede birden fazla Background Music var");
        }
        DontDestroyOnLoad(gameObject); // Gameoverdan sonra sürekli sürekli ayný müzik çalmasýn müzik kaldýðý yerden devam etsin diye yaptýk.
    }

    private void Update()
    {
        MuteMusic();
    }

    void MuteMusic()
    {
        if(PauseMenuScript.isPause)
        {
            audioSource.mute = true;
            //Debug.Log("Mute Music");
        }
        else
        {
            audioSource.mute = false;
            //Debug.Log("Play Music");
        }
    }
}
