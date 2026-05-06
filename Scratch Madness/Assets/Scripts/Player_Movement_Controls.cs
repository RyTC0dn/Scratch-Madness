using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Movement_Controls : MonoBehaviour
{
    [Header("Player Component Settings")]
    private Rigidbody2D rb;
    public GameObject rotationPoint;

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

    //This method is to define the movement inputs
    //with keyboard or left joystick
    public void Move(InputAction.CallbackContext context)
    {
        // Read the movement input values from the context and
        // store them in the moveInputX and moveInputY variables
        moveInputX = context.ReadValue<Vector2>().x;
        moveInputY = context.ReadValue<Vector2>().y;
    }

    //This method is to define the inputs for being able to aim
    //with mouse or right joystick
    public void Aim(InputAction.CallbackContext context)
    {
        Vector2 aimInput = context.ReadValue<Vector2>();
        // Calculate the angle between the player and the aim input
        float angle = Mathf.Atan2(aimInput.y, aimInput.x) * Mathf.Rad2Deg;
        // Rotate the weapon in the direction of the aim input
        rotationPoint.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    #endregion Player Input Methods
}