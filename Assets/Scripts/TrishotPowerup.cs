using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class TrishotPowerUp : MonoBehaviour
{
    public GameObject BaseGunsHolder;
    public GameObject BoomGun;
    public GameObject Trishot;
    public float PowerupDuration = 7f;

    private void Update()
    {
        if (BoomGun.activeInHierarchy == true)
        {
            
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) 
    {
        BaseGunsHolder = collision.gameObject.transform.GetChild(0).gameObject;
        BoomGun = collision.gameObject.transform.GetChild(3).gameObject;
        Trishot = collision.gameObject.transform.GetChild(4).gameObject;
        StartCoroutine(PowerupTri());
    }

    private IEnumerator PowerupTri()
    {
        BaseGunsHolder.SetActive(false);
        BoomGun.SetActive(false);
        Trishot.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Light2D>().enabled = false;
        gameObject.GetComponent<ShadowCaster2D>().enabled = false;
        gameObject.GetComponent<Shadow>().enabled = false;
        yield return new WaitForSeconds(PowerupDuration);
        BaseGunsHolder.SetActive(true);
        Trishot.SetActive(false);
        Destroy(gameObject);
    }
}
