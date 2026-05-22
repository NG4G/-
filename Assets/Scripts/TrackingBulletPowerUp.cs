using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class TrackingBulletPowerUp : MonoBehaviour
{
    public GameObject BaseGunsHolder;
    public GameObject BoomGun;
    public GameObject Trishot;
    public GameObject TrackingGun;
    public float PowerupDuration = 10f;

     void Update()
    {
        if (Trishot.activeInHierarchy == true)
        {  
            Destroy(gameObject);
        }
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
        TrackingGun = collision.gameObject.transform.GetChild(5).gameObject;
        StartCoroutine(PowerupTracking());
    }

    private IEnumerator PowerupTracking()
    {
        BaseGunsHolder.SetActive(false);
        BoomGun.SetActive(false);
        Trishot.SetActive(false);
        TrackingGun.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Light2D>().enabled = false;
        gameObject.GetComponent<ShadowCaster2D>().enabled = false;
        gameObject.GetComponent<Shadow>().enabled = false;
        yield return new WaitForSeconds(PowerupDuration);
        BaseGunsHolder.SetActive(true);
        BoomGun.SetActive(false);
        Destroy(gameObject);
    }
}
