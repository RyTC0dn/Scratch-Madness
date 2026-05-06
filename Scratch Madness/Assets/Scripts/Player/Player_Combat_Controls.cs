using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Combat_Controls : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firepoint;

    public void Shoot(InputAction.CallbackContext context)
    {
        //If the shoot input is performed
        if (context.performed)
        {
            // Instantiate the bullet prefab at the firepoint's position and rotation
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        }
    }
}