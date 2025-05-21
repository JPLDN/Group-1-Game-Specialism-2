using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyMovement : MonoBehaviour
{
    public float horizontalSpeed = 3f;
    public float verticalAmplitude = 5f;
    public float verticalFrequency = 2f;

    private Vector2 direction;
    private float initialY;
    private float timeCounter;

    // Start is called before the first frame update
    void Start()
    {
        direction = (transform.position.x < 0) ? Vector2.right : Vector2.left;

        initialY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        
        Vector3 horizontalMovement = (Vector3)direction * horizontalSpeed * Time.deltaTime;

        float verticalOffset = Mathf.Sin(timeCounter * verticalFrequency) * verticalAmplitude;
        Vector3 newPosition = transform.position + horizontalMovement;
        newPosition.y = initialY + verticalOffset;

        transform.position = newPosition;
    }
}
