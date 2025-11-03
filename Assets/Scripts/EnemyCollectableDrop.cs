

using UnityEngine;

public class EnemyCollectableDrop : MonoBehaviour
{
    [SerializeField]
    private float _chanceOfCollectabledrop;

    private CollectableSpawner _collectableSpawner;

    private void Awake()
    {
        _collectableSpawner = FindFirstObjectByType<CollectableSpawner>();
    }

    public void RandomlyDropCollectable()
    {
        float random = Random.Range(0f, 1f);

        if (_chanceOfCollectabledrop >= random)
        {
            _collectableSpawner.SpawnCollectable(transform.position);
        }
    }
}
