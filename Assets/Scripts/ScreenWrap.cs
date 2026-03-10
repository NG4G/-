using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ScreenWrap : MonoBehaviour
{

    public Camera camera1;
    private Rigidbody2D rb2d;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        camera1 = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {

        // Get the screen position of object in Pixels
        Vector3 screenPos = camera1.WorldToScreenPoint(transform.position);

        //Get the right side of the screen in world units 
        float rightSideOfScreenInWorld = camera1.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float leftSideOfScreenInWorld = camera1.ScreenToWorldPoint(new Vector2(0f, 0f)).x;

        float topOfScreenInWorld = camera1.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        float bottomOfScreenInWorld = camera1.ScreenToWorldPoint(new Vector2(0f, 0f)).y;

        //if player is moving through left side of the screen 
        if  (screenPos.x <= 0 && rb2d.linearVelocity.x < 0) 
        {
            transform.position = new Vector2(rightSideOfScreenInWorld, transform.position.y);
            TryGetComponent<TrailRenderer>(out TrailRenderer trail);
            if(trail != null)
            {
                trail.emitting = false;
            }

        }
        //player is moving through right side of the screen
        else if (screenPos.x >= Screen.width && rb2d.linearVelocity.x > 0)
        {
            transform.position = new Vector2(leftSideOfScreenInWorld, transform.position.y);
            TryGetComponent<TrailRenderer>(out TrailRenderer trail);
            if(trail != null)
            {
                trail.emitting = false;
            }
        }
        // if player is moving through top of the screen
        else if (screenPos.y >= Screen.height && rb2d.linearVelocity.y > 0)
        {
            transform.position = new Vector2(transform.position.x, bottomOfScreenInWorld);
            TryGetComponent<TrailRenderer>(out TrailRenderer trail);
            if (trail != null)
            {
                trail.emitting = false;
            }
        }
        // if player is moving through bottom of the screen
        else if (screenPos.y <= 0 && rb2d.linearVelocity.y < 0)
        {
            transform.position = new Vector2(transform.position.x, topOfScreenInWorld);
            TryGetComponent<TrailRenderer>(out TrailRenderer trail);
            if(trail != null)
            {
                trail.emitting = false;
            }
        }
    }
}
