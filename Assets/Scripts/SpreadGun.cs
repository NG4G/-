using Unity.VisualScripting;
using UnityEngine;

public class SpreadGun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float rotationOffset;
    public int numberOfbullets;
    public float bulletSpeed, bulletSpread, shootCooldown;
    public GameObject bulletPrefab;
    public Transform shootPosition;
    float shootstartcooldown;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle+ rotationOffset, Vector3.forward);

        if (shootstartcooldown <= 0)
        {

            if (Input.GetMouseButtonDown(2))
            {
                Shoot();
                shootstartcooldown = shootCooldown;
            }
            
        }
        else
        {
            shootstartcooldown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        for (int i = 0; i < numberOfbullets; i++)
        {
            GameObject a = Instantiate(bulletPrefab, shootPosition.position, transform.rotation);
            Rigidbody2D arb = a.GetComponent<Rigidbody2D>();
            Vector2 dir = transform.rotation * Vector2.up;
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-bulletSpread, bulletSpread);
            arb.linearVelocity = (dir + pdir) * bulletSpeed;
        }

    }
}
