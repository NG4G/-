using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class BoomPowerUp : MonoBehaviour
{
    public GameObject GunsHolder;
    public GameObject BoomGun;
    public float PowerupDuration = 7f;

    public void OnTriggerEnter2D(Collider2D collision) 
    {
        GunsHolder = collision.gameObject.transform.GetChild(0).gameObject;
        BoomGun = collision.gameObject.transform.GetChild(2).gameObject;
        StartCoroutine(Powerup());
    }

    private IEnumerator Powerup()
    {
        GunsHolder.SetActive(false);
        BoomGun.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Light2D>().enabled = false;
        gameObject.GetComponent<ShadowCaster2D>().enabled = false;
        gameObject.GetComponent<Shadow>().enabled = false;
        yield return new WaitForSeconds(PowerupDuration);
        GunsHolder.SetActive(true);
        BoomGun.SetActive(false);
        Destroy(gameObject);
    }
}
