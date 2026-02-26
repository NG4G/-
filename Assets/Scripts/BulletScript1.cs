using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class BulletScript1 : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public float bDamage;
    public GameObject child;
    public bool notCollideBoom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        child.SetActive(false);

        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && collision.gameObject.TryGetComponent(out Stats stats))
        {
            child.SetActive(true);
            child.transform.parent = null;
            float calculatedDamage = bDamage -= stats.defense;
            stats.currentHealth -= calculatedDamage;
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Terrain"))
        {
            Destroy(gameObject);
        }
        
        
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        notCollideBoom = true;
        child.SetActive(true);
        child.transform.parent = null;
        Destroy(gameObject);
    }
    



}
