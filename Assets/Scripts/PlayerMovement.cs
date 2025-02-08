using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Variables for Player Movement
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 moveInput;

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
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }
}
