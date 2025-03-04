using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform player;
    private bool isMoving = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("Player not found!");
        }
    }

    public void StartMoving()
    {
        isMoving = true; 
    }

    void Update()
    {
        if (isMoving && player != null)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }
}
