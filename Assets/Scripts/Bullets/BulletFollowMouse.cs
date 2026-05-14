using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BulletFollowMouse : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public float bDamage;
    public float _rotationSpeed;
    public bool canHitPlayer;
    public Vector2 _targetDirection;
    public Vector2 DirectionToMouse { get; private set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(canHitP());
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        

        
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(
           mousePos.x - transform.position.x,
           mousePos.y - transform.position.y);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

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

    private void UpdateTargetDirection()
    {
        _targetDirection = DirectionToMouse;
    }

    private void RotateTowardsTarget()
    {
        

       ;
    }


}
