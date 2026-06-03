using UnityEngine;
using TMPro;

public class CurrentGunUI : MonoBehaviour
{
    private TMP_Text GunText;
    private gunScrip gunHolder;

    public GameObject boomGun;
    public GameObject trishot;
    public GameObject trackingGun;

    private void Awake()
    {
        GunText = GetComponent<TMP_Text>();
        gunHolder = GameObject.Find("GunsHolder").GetComponent<gunScrip>();
        boomGun = GameObject.Find("Boom Gun");
        trishot = GameObject.Find("Trishot");
        trackingGun = GameObject.Find("Tracking Gun");
    }

    public void Update()
    {


        if (boomGun.activeSelf)
        {
            GunText.text = "Weapon: Boom Gun";
        }
        else if (trishot.activeSelf)
        {
            GunText.text = "Weapon: Trishot";
        }
        else if (trackingGun.activeSelf)
        {
            GunText.text = "Weapon: Tracking Gun";
        }
        else
        {
            GunText.text = $"Weapon: {gunHolder.currentGun.name}";
        }
    }
}
