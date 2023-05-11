using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            winPanel.SetActive(true) ;
            LevelManager.canMove = false;
            SoundManager.instance.WinSound();
        }
    }
}
