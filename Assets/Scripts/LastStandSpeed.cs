using UnityEngine;

public class LastStandSpeed : MonoBehaviour
{

    public topDownMovement playerMovement;
    public Stats playerStats;
    public GameObject SpreadGun;
    public GameObject RapidFireGun;
    public GameObject SingleFire;
    public GameObject BoomFire;
    public GameObject Trishot1;
    public GameObject Trishot2;
    public GameObject Trishot3;
    


    // Update is called once per frame
    void Update()
    {
        if(playerStats.currentHealth <= 7f)
        {
            playerMovement.currentSpeed = 15f;
            SpreadGun.GetComponent<SpreadGun>().shootCooldown = 0.9f;
            RapidFireGun.GetComponent<SpreadGun>().shootCooldown = 0.1f;
            SingleFire.GetComponent<Shooting>().timeBetweenFiring = 0.3f;
            playerMovement.dashSpeed = 30f;
            BoomFire.GetComponent<ShootingPower>().timeBetweenFiring = 0.7f; 
            Trishot1.GetComponent<Shooting>().timeBetweenFiring = 0.6f;
            Trishot2.GetComponent<Shooting>().timeBetweenFiring = 0.6f;
            Trishot3.GetComponent<Shooting>().timeBetweenFiring = 0.6f;

        }
         else
         {
            playerMovement.currentSpeed = 8f;
            SpreadGun.GetComponent<SpreadGun>().shootCooldown = 1.1f;
            RapidFireGun.GetComponent<SpreadGun>().shootCooldown = 0.15f;
            SingleFire.GetComponent<Shooting>().timeBetweenFiring = 0.5f;
            playerMovement.dashSpeed = 25f;
            BoomFire.GetComponent<ShootingPower>().timeBetweenFiring = 0.85f;
            Trishot1.GetComponent<Shooting>().timeBetweenFiring = 0.75f;
            Trishot2.GetComponent<Shooting>().timeBetweenFiring = 0.75f;
            Trishot3.GetComponent<Shooting>().timeBetweenFiring = 0.75f;
        }
    }
}
