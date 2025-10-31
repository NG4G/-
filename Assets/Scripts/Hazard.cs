using UnityEngine;

public class Hazard : MonoBehaviour
{

    public float damage = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && collision.gameObject.TryGetComponent(out Stats stats))
        {
          
             stats.currentHealth -= damage;
            
        }
    }
}
