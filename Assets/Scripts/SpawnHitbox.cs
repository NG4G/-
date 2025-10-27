using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnHitbox : MonoBehaviour
{
    public float attackDistance;
    public float knockbackForce = 50;
    public float attackRadius = 1.5f;
    public LayerMask attackLayer;

    private topDownMovement topDown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        topDown = GetComponent<topDownMovement>();
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0) //Released
            return;

        Vector2 Mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 CirclePos = (Mousepos - (Vector2)transform.position).normalized;
        RaycastHit2D hit = Physics2D.CircleCast(transform.position + (Vector3)CirclePos * attackDistance, 1.5f, Vector2.zero, 0, attackLayer);

        if (hit)
        {
            Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.TryGetComponent(out Stats targetStats) && TryGetComponent(out Stats playerStats))
            {
                float calculatedDamage = playerStats.damage - targetStats.defense;
                targetStats.currentHealth -= calculatedDamage;
                GetComponent<Enemy_Knockback>().Knockback(transform, knockbackForce);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector2 Mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 CirclePos = (Mousepos - (Vector2)transform.position).normalized;
        Gizmos.DrawWireSphere(transform.position + (Vector3)CirclePos * attackDistance, attackRadius);
    }

}
