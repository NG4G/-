using UnityEngine;
using UnityEngine.UI;

public class StatsHUD : MonoBehaviour
{
    public Stats stats;

    public Image healthBar;
    public Image manaBar;
    

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = stats.currentHealth / stats.maxHealth;
        manaBar.fillAmount = stats.currentHealth / stats.maxMana;
    }
}
