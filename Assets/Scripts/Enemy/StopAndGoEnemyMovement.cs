using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAndGoEnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveDuration = 1;
    public float pauseDuration = 0.3f;
    public float arcHeight = 2f;

    private Vector2 direction;
    private float timer;
    private bool isMoving = true;

    private Vector3 moveStartPos;

    // Start is called before the first frame update
    void Start()
    {
        direction = (transform.position.x < 0) ? Vector2.right : Vector2.left;
        timer = moveDuration;
        moveStartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (isMoving)
        {
            float t = 1f - (timer / moveDuration);
            t = Mathf.Clamp01(t);

            Vector3 newPos = moveStartPos + (Vector3)(direction * moveSpeed * moveDuration * t);

            float arcOffset = Mathf.Sin(t * Mathf.PI) * arcHeight;
            newPos.y += arcOffset;

            transform.position = newPos;

            if (timer <= 0f)
            {
                isMoving = false;
                timer = pauseDuration;
            }
        }
        else
        {
            if (timer <= 0f)
            {
                isMoving = true;
                timer = moveDuration;
                moveStartPos = transform.position;
            }
        }

    }
}
