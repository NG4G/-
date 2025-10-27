using UnityEngine;
using UnityEngine.UI;

public class StatsHUD : MonoBehaviour
{
    public Stats stats;

    public Image healthbar;
    public Image manaBar;
    

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = stats.currentHealth / stats.maxHealth;
        manaBar.fillAmount = stats.currentMana / stats.maxMana;
    }
}
