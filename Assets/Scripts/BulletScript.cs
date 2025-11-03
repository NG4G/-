using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public float bDamage;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && collision.gameObject.TryGetComponent(out Stats stats))
        {

            stats.currentHealth -= bDamage;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Terrain"))
        {
            Destroy(gameObject);
        }
        
        
    }
    



}
