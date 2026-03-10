using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class BoomPowerUp : MonoBehaviour
{
    public GameObject BaseGunsHolder;
    public GameObject BoomGun;
    public GameObject Trishot;
    public float PowerupDuration = 7f;

     void Update()
    {
        if (Trishot.activeInHierarchy == true)
        {  
            Destroy(gameObject);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision) 
    {
        BaseGunsHolder = collision.gameObject.transform.GetChild(0).gameObject;
        BoomGun = collision.gameObject.transform.GetChild(3).gameObject;
        Trishot = collision.gameObject.transform.GetChild(4).gameObject;
        StartCoroutine(PowerupBOOM());
    }

    private IEnumerator PowerupBOOM()
    {
        BaseGunsHolder.SetActive(false);
        BoomGun.SetActive(true);
        Trishot.SetActive(false);
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
