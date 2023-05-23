using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject runText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            winPanel.SetActive(true) ;
            runText.SetActive(false);
            SoundManager.instance.WinSound();
            collision.gameObject.SetActive(false); //kapýya girince herþey duracak
        }
    }
}
