using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    //[SerializeField] SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        //soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //soundManager.LandSound();
            SoundManager.instance.PlayWithIndex(10);
        }
    }
}
