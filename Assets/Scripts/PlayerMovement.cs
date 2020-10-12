using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float xDir;
    private float yDir;
    private float facingValue;
    Vector2 movement;
    Vector2 mousePos;

    Rigidbody2D rbPlayer;
    public Transform bulletSpawn;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        rbPlayer.MovePosition(rbPlayer.position + movement * speed * Time.deltaTime);

        Vector2 lookDir = mousePos - (Vector2)transform.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;

        rbPlayer.rotation = angle;
    }

    void GetInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
