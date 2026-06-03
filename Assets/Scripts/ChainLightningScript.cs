using System.Collections;
using UnityEngine;

public class ChainLightningScript : MonoBehaviour
{

    private CircleCollider2D coll;

    public LayerMask enemyLayer;
    public float damage;

    public GameObject chainLightningEffect;

    public GameObject beenStruck;

    public int amountToChain;

    private GameObject startObject;
    private GameObject endObject;

    private Animator ani;

    public ParticleSystem parti;

    private int singleSpawns;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (amountToChain == 0)
        {
            Destroy(gameObject);
        }

        StartCoroutine(DurationTopreventBuildup());

        coll = GetComponent<CircleCollider2D>();

        ani = GetComponent<Animator>();

        startObject = gameObject;

        parti = GetComponent<ParticleSystem>();

        singleSpawns = 1;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemyLayer == (enemyLayer | (1 << collision.gameObject.layer)) && !collision.GetComponentInChildren<EnemyStruck>())
        {

            if (singleSpawns != 0)
            {

                endObject = collision.gameObject;

                amountToChain -= 1;

                Instantiate(chainLightningEffect, collision.gameObject.transform.position, Quaternion.identity);

                Instantiate(beenStruck, collision.gameObject.transform);

                collision.gameObject.GetComponent<Stats>().currentHealth -= damage;

                ani.StopPlayback();

                coll.enabled = false;

                singleSpawns--;

                parti.Play();

                var emitParams = new ParticleSystem.EmitParams();
                emitParams.position = startObject.transform.position;

                parti.Emit(emitParams, 1);

                emitParams.position = endObject.transform.position;

                parti.Emit(emitParams, 1);

                emitParams.position = (startObject.transform.position + endObject.transform.position) / 2;

                parti.Emit(emitParams, 1);

                Destroy(gameObject, 1f);
            }
        }     
    }

    private IEnumerator DurationTopreventBuildup()
            {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
