using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BoomPowerUp : MonoBehaviour
{
    public GameObject GunsHolder;
    public GameObject BoomGun;

    private void Start()
    {
        GunsHolder = GameObject.FindGameObjectWithTag("Guns").gameObject;
        BoomGun = GameObject.FindGameObjectWithTag("Gun").gameObject;
        BoomGun.SetActive(false);
    }

    private void Update()
    {
        BoomGun = GameObject.FindGameObjectWithTag("Gun").gameObject;

    }

    public void OnTriggerEnter2D() 
    {
        StartCoroutine(Powerup());
    }

    private IEnumerator Powerup()
    {
        GunsHolder.SetActive(false);
        BoomGun.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(3f);
        GunsHolder.SetActive(true);
        BoomGun.SetActive(false);
        Destroy(gameObject);
    }
}
