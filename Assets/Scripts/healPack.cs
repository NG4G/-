using UnityEngine;

public class healPack : MonoBehaviour
{
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health") && collision.gameObject.TryGetComponent(out Stats targetStats) && TryGetComponent(out Stats playerStats))

        {
            playerStats.currentHealth += targetStats.healing;
            Destroy(collision.gameObject);
        }
    }
}
