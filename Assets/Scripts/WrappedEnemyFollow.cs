using UnityEngine;

public class WrappedEnemyFollow : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    private Camera cam;
    private float screenWidth;
    private float screenHeight;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        cam = Camera.main;
        // Calculate screen boundaries
        screenHeight = cam.orthographicSize;
        screenWidth = screenHeight * cam.aspect;
    }

    void Update()
    {
        Vector3 targetPos = player.transform.position;
        Vector3 currentPos = transform.position;

        // --- Basic Chase ---
        // Basic AI movement towards player [6]
        Vector2 newPos = Vector2.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);

        // --- Screen Wrap Logic ---
        // If player is far to the right, teleport left (or move towards that side)
        if (Mathf.Abs(targetPos.x - currentPos.x) > screenWidth / 2)
        {
            targetPos.x = -targetPos.x; // Simplified wrap target
        }

        // --- Apply Movement ---
        transform.position = Vector2.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);

        // --- Optional: Actual Teleportation ---
        // If enemy goes off-screen, teleport to the other side [12]
        if (transform.position.x > screenWidth / 2)
            transform.position = new Vector3(-screenWidth / 2, transform.position.y, 0);
        else if (transform.position.x < -screenWidth / 2)
            transform.position = new Vector3(screenWidth / 2, transform.position.y, 0);
    }
}
