using UnityEngine;

public class BulletAwareness : MonoBehaviour
{

    public bool AwareOfPlayer { get; private set; }
   

    public Vector2 DirectionToPlayer {  get; private set; }

    private Camera cam;
    private float screenWidth;
    private float screenHeight;

    [SerializeField]
    private float _playerAwarenessDsitance;

    

    private Vector2 mousePos;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cam = Camera.main;
        
        screenHeight = cam.orthographicSize;
        screenWidth = screenHeight * cam.aspect;

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 enemyToPlayerVector = mousePos - (Vector2)transform.position;
        Vector3 targetPos = mousePos;
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
