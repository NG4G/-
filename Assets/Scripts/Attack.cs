using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject Melee;
    bool isAttacking = false;
    float atkDuration = 0.3f;
    float atkTimer = 0f;

    // Update is called once per frame
    void Update()
    {

        CheckMeleeTimer();

        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(0))
        {
            //Attack
        }
    }

    void OnAttack()
    {
        if (!isAttacking)
        {
            Melee.SetActive(true);
            isAttacking = true;
        }
    }

    void CheckMeleeTimer()
    {
        atkTimer += Time.deltaTime;
        if (atkTimer >= atkDuration)
        {
            atkTimer = 0f;
            isAttacking = false;
            Melee.SetActive(false);
        }
    }

}
