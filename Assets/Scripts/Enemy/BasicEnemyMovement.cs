using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 moveDirection;

    public void Start()
    {
        if (transform.position.x < 0)
        {
            moveDirection = Vector2.right;
        }
        else
        {
            moveDirection = Vector2.left;
        }
    }

    public void Update()
    {
        transform.position += (Vector3)moveDirection.normalized * moveSpeed * Time.deltaTime;
    }
}
