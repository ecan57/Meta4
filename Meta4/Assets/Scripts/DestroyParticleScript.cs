using UnityEngine;

public class DestroyParticleScript : MonoBehaviour
{
    [SerializeField] float time;

    void Start()
    {
        Destroy(gameObject, time);
    }
}
