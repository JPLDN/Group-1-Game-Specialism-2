using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        SetNewTargetPosition();
    }

    public void StartMoving()
    {
        SetNewTargetPosition();
    }

    void SetNewTargetPosition()
    {
        Camera mainCamera = Camera.main;
        float screenHeight = mainCamera.orthographicSize * 2;
        float screenWidth = screenHeight * mainCamera.aspect;

        targetPosition = new Vector3(Random.Range(-screenWidth / 2, screenWidth / 2), Random.Range(-screenHeight / 2, screenHeight / 2), 0f);
    }

    void Update()
    {
        if (targetPosition != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                SetNewTargetPosition();
            }
        }
    }
}
