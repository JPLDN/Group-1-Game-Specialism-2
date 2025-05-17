using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Variables for Player Movement
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 moveInput;

    private bool faceRight = true;

    public bool IsFaceRight => faceRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; 
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector3(moveX, moveY, 0).normalized;

        if (moveX > 0 && !faceRight)
        {
            Flip();
        }
        else if (moveX < 0 && faceRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    void Flip()
    {
        faceRight = !faceRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
