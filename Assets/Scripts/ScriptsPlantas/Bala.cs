using UnityEngine;

public class Bala : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        ZombieScripts z = collision.GetComponent<ZombieScripts>();

        z.HacerDano(20);

        Bala.Destroy(gameObject);

        Debug.Log("Entrat");

    }

}
