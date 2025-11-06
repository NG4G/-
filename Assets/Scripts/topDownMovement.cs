using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class topDownMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;

    private Vector2 movement;
    private float currentSpeed;
    private Rigidbody2D rb2D;

    [HideInInspector] public Vector2 direction;
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();

        currentSpeed = walkSpeed;
        direction = Vector2.down;
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.linearVelocity = movement * currentSpeed;
        
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<Vector2>();

        if (ctx.ReadValue<Vector2>() != Vector2.zero)
        {
            direction = ctx.ReadValue<Vector2>();
        }
        
    }

    public void Run(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1) //Pressed
        {
            currentSpeed = runSpeed;
        }
        else //Released
        {
            currentSpeed = walkSpeed;
        }
    }
}
