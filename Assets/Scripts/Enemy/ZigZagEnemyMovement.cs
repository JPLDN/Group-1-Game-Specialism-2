using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagEnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float zigzagAmplitude = 1f;
    public float zigzagFrequency = 2f;

    private Vector2 moveDirection;
    private float startY;
    private float timeOffset;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x < 0)
        {
            moveDirection = Vector2.right;
        }
        else
        {
            moveDirection = Vector2.left;
        }

        startY = transform.position.y;
        timeOffset = Random.Range(0f, 2f * Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = moveDirection.x * moveSpeed * Time.deltaTime;
        float vertical = Mathf.Sin(Time.time * zigzagFrequency + timeOffset) * zigzagAmplitude * Time.deltaTime;

        transform.position += new Vector3(horizontal, vertical, 0f);
    }
}
