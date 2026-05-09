using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Movement_Controls : MonoBehaviour
{
    [Header("Player Component Settings")]
    private Rigidbody2D rb;
    public GameObject rotationPoint;

    [Space(20)]
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    private Vector2 mousePos;

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
        if (DeviceCheck(context.control.device))
        {
            Vector2 aimInput = context.ReadValue<Vector2>();
            // Calculate the angle between the player and the aim input
            float angle = Mathf.Atan2(aimInput.y, aimInput.x) * Mathf.Rad2Deg;
            // Rotate the weapon in the direction of the aim input
            rotationPoint.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        else
        {
            mousePos = context.ReadValue<Vector2>();
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
            Vector2 direction = (worldMousePos - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rotationPoint.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    public bool DeviceCheck(InputDevice device)
    {
        // Check if the device is a gamepad
        if (device is Gamepad)
        {
            // If it's a gamepad, we can use the left stick for movement
            return true;
        }

        // If it's not a gamepad, we can use the keyboard
        return false;
    }

    #endregion Player Input Methods
}