using UnityEngine;

public class PlayerBoundry : MonoBehaviour
{
    [SerializeField] float horizontalBoundry;

    float xMove; //kapal� ifler yerine Mathf.Clamp kulland�k
    //y ekseni i�imn de yapabilirsin

    // Update is called once per frame
    void Update()
    {
        xMove = Mathf.Clamp(transform.position.x, -horizontalBoundry, horizontalBoundry); //x ekseni boyunca + ve - s�n�rlar aras�nda kals�n 
        transform.position = new Vector2(xMove, transform.position.y);

        //if (transform.position.x < -horizontalBoundry) 
        //{
        //    transform.position = new Vector3(-horizontalBoundry, transform.position.y, transform.position.z);
        //}
        //if (transform.position.x > horizontalBoundry)
        //{
        //    transform.position = new Vector3(horizontalBoundry, transform.position.y, transform.position.z);
        //}
    }
}
