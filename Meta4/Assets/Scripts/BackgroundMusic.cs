using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;

    public static BackgroundMusic instance; //singleton kullan�m�

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); //gameobject dedi�imiz background music. �al��t�r�nca birden fazla varsa yok et.
            //Debug.Log("Sahnede birden fazla Background Music var");
        }
        DontDestroyOnLoad(gameObject); // Gameoverdan sonra s�rekli s�rekli ayn� m�zik �almas�n m�zik kald��� yerden devam etsin diye yapt�k.
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
