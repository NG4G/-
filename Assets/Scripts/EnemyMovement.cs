using System.Runtime.InteropServices;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyMovement : MonoBehaviour
{
    public float _speed;

    private float screenWidth;
    private float screenHeight;

    public float _rotationSpeed;
    private Transform _player;
    private Camera cam;


    private Rigidbody2D _rigidbody;
    private PlayerAwarenessScript _playerAwarenessController;
    private Vector2 _targetDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cam = Camera.main;

        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessScript>();
        _player = FindFirstObjectByType<topDownMovement>().transform;
        screenHeight = cam.orthographicSize;
        screenWidth = screenHeight * cam.aspect;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        Vector3 targetPos = _player.transform.position;
        Vector3 position = transform.position;
        Vector3 screenPos = cam.WorldToScreenPoint(transform.position);

        if (_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }

        if (Mathf.Abs(targetPos.x - position.x) > screenWidth  && _playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection.x = -targetPos.x; // Simplified wrap target
        }
        if(Mathf.Abs(targetPos.y - position.y) > screenHeight && _playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection.y = -targetPos.y; // Simplified wrap target
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
