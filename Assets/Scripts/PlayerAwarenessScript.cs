using UnityEngine;

public class PlayerAwarenessScript : MonoBehaviour
{

    public bool AwareOfPlayer { get; private set; }
   

    public Vector2 DirectionToPlayer {  get; private set; }

    private Camera cam;
    private float screenWidth;
    private float screenHeight;

    [SerializeField]
    private float _playerAwarenessDsitance;

    

    private Transform _player;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cam = Camera.main;
        _player = FindFirstObjectByType<topDownMovement>().transform;
        screenHeight = cam.orthographicSize;
        screenWidth = screenHeight * cam.aspect;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        Vector3 targetPos = _player.transform.position;
        Vector3 currentPos = transform.position;


        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _playerAwarenessDsitance)
        {
            AwareOfPlayer = true;

        }
        
        else
        {
            AwareOfPlayer = false;
        }
        


    }
}
