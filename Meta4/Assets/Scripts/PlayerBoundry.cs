using UnityEngine;

public class PlayerBoundry : MonoBehaviour
{
    [SerializeField] float horizontalBoundry;

    float xMove; //kapalý ifler yerine Mathf.Clamp kullandýk
    //y ekseni içimn de yapabilirsin

    // Update is called once per frame
    void Update()
    {
        xMove = Mathf.Clamp(transform.position.x, -horizontalBoundry, horizontalBoundry); //x ekseni boyunca + ve - sýnýrlar arasýnda kalsýn 
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
