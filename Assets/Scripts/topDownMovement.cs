using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody2D))]

public class topDownMovement : MonoBehaviour
{
    public float walkSpeed;
    [SerializeField] private TrailRenderer tr;
    
    private PlayerInput playerInput;

    private Vector2 movement;
    public float currentSpeed;
    private Rigidbody2D rb2D;

    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldown = 1f;
    bool isDashing;
    bool canDash;

    [HideInInspector] public Vector2 direction;
    void Awake()
    {
        tr = GetComponent<TrailRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        currentSpeed = walkSpeed;
        direction = Vector2.down;
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        var dashAction = playerInput.actions["Dash"];
        rb2D.linearVelocity = movement * currentSpeed;

        if (dashAction.WasPerformedThisFrame() && dashAction != null && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<Vector2>();

        if (ctx.ReadValue<Vector2>() != Vector2.zero)
        {
            direction = ctx.ReadValue<Vector2>();
        }

    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb2D.linearVelocity = movement * dashSpeed;
        tr.emitting = true;
        yield return new WaitForSeconds(dashDuration); 
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }


}
