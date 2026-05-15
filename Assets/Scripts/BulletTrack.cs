using UnityEngine;


public class BulletTrack : MonoBehaviour
{
    public float _speed;

    private float screenWidth;
    private float screenHeight;

    public float _rotationSpeed;
    private Vector2 mousePos;
    private Camera cam;


    private Rigidbody2D _rigidbody;
    private BulletAwareness _bulletAwarenessController;
    private Vector2 _targetDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cam = Camera.main;

        _rigidbody = GetComponent<Rigidbody2D>();
        _bulletAwarenessController = GetComponent<BulletAwareness>();
        
        screenHeight = cam.orthographicSize;
        screenWidth = screenHeight * cam.aspect;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        Vector3 targetPos = mousePos;
        Vector3 position = transform.position;
        Vector3 screenPos = cam.WorldToScreenPoint(transform.position);

        if (_bulletAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _bulletAwarenessController.DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }

        
    }        
        
    

    private void RotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rigidbody.linearVelocity = Vector2.zero;
        }
        else
        {
            _rigidbody.linearVelocity = transform.up * _speed;
        }
    }
}
