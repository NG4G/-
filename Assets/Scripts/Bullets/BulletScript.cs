using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public float bDamage;
    public bool canHitPlayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(canHitP());
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && collision.gameObject.TryGetComponent(out Stats stats))
        {
            
            float calculatedDamage = bDamage -= stats.defense;
            stats.currentHealth -= calculatedDamage;
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Terrain"))
        {
            Destroy(gameObject);
        }
        
        if(collision.gameObject.CompareTag("Player") && collision.gameObject.TryGetComponent(out Stats playerStats) && canHitPlayer == true)
        {
            float calculatedDamage = bDamage -= playerStats.defense;
            playerStats.currentHealth -= calculatedDamage;
            Destroy(gameObject);
        }

    }

    private IEnumerator canHitP()
    {
               yield return new WaitForSeconds(1f);
               canHitPlayer = true;

    }
    



}
