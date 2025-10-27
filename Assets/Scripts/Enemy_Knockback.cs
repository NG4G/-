using UnityEngine;

public class Enemy_Knockback : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Knockback(Transform playerTransform, float knockbackForce)
    {
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb.angularVelocity = direction * knockbackForce;
        Debug.Log("knoooooockbaaaaack!");
    }
}
