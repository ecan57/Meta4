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
            
            //SoundManager.instance.WinSound();
            SoundManager.instance.PlayWithIndex(13);
            
            collision.gameObject.SetActive(false); //kapýya girince herþey duracak
        }
    }
}
