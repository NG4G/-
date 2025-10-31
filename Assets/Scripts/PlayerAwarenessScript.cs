using UnityEngine;

public class PlayerAwarenessScript : MonoBehaviour
{

    public bool AwareOfPlayer { get; private set; }
    
    public Vector2 DirectionToPlayer {  get; private set; }

    [SerializeField]
    private float _playerAwarenessDsitance;

    private Transform _player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _player = FindFirstObjectByType<topDownMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if(enemyToPlayerVector.magnitude <= _playerAwarenessDsitance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
