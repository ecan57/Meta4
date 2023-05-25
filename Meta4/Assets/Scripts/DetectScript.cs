using UnityEngine;

public class DetectScript : MonoBehaviour
{
    private GunScript gun;

    private void Awake()
    {
        gun = GameObject.Find("Gun").GetComponent<GunScript>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //turrent ate� edecek
        if (collision.gameObject.CompareTag("Player"))
        {
            gun.isClose = true;
            gun.Fire();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //turrent ate� etmeyi b�rakacak
        if (collision.gameObject.CompareTag("Player"))
            gun.isClose = false;
    }
    
}
