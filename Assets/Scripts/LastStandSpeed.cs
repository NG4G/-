using UnityEngine;

public class LastStandSpeed : MonoBehaviour
{

    public topDownMovement playerMovement;
    public Stats playerStats;
    public GameObject SpreadGun;
    public GameObject RapidFireGun;
    public GameObject SingleFire;


    // Update is called once per frame
    void Update()
    {
        if(playerStats.currentHealth <= 7f)
        {
            playerMovement.currentSpeed = 15f;
            SpreadGun.GetComponent<SpreadGun>().shootCooldown = 0.8f;
            RapidFireGun.GetComponent<SpreadGun>().shootCooldown = 0.1f;
            SingleFire.GetComponent<Shooting>().timeBetweenFiring = 0.3f;

        }
         else
         {
            playerMovement.currentSpeed = 8f;
            SpreadGun.GetComponent<SpreadGun>().shootCooldown = 1.25f;
            RapidFireGun.GetComponent<SpreadGun>().shootCooldown = 0.15f;
            SingleFire.GetComponent<Shooting>().timeBetweenFiring = 0.5f;
        }
    }
}
