using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private GameObject bulletPrefab;
    private GameObject newBullet;
    private Vector2 worldMousePosition;
    private Vector2 shootDirection;
    private float bulletSpeed = 23f;
    private float moveSpeed = 350;
    private Vector2 inputValue;
    void Update()
    {
        worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        playerRb.velocity = inputValue * moveSpeed * Time.deltaTime;
        shootDirection = worldMousePosition - playerRb.position;
        shootDirection.Normalize();
    }

    public void Movement(InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>();
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddForce(shootDirection * bulletSpeed, ForceMode2D.Impulse);
    }
}
