using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 moveDirection = Vector2.left;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)moveDirection.normalized * moveSpeed * Time.deltaTime;
    }
}
