using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Movement_Controls : MonoBehaviour
{
    [Header("Player Component Settings")]
    private Rigidbody2D rb;

    public float moveSpeed = 5f;

    private float moveInputX;
    private float moveInputY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInputX * moveSpeed, moveInputY * moveSpeed);
    }

    #region Player Input Methods

    public void Move(InputAction.CallbackContext context)
    {
        // Read the movement input values from the context and
        // store them in the moveInputX and moveInputY variables
        moveInputX = context.ReadValue<Vector2>().x;
        moveInputY = context.ReadValue<Vector2>().y;
    }

    #endregion Player Input Methods
}