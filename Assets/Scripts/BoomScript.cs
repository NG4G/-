using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class BoomScript : MonoBehaviour
{
    
    public float bDamage;
   




    // Update is called once per frame
    void Update()
    {
        if(transform.parent == null)
        {
            StartCoroutine(Wait());
           
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && collision.gameObject.TryGetComponent(out Stats stats))
        {
            float calculatedDamage = bDamage -= stats.defense;
            stats.currentHealth -= calculatedDamage;
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            
            

        }
        
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }


}
