using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowStage : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.5f;

    public float minY = -5f;
    public float maxY = 5f;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera.orthographic == false)
        {
            Debug.Log("Camera isn't Orthographic");  // Testing to see if orthographic project is not set
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        float targetY = player.position.y + offset.y;

        targetY = Mathf.Clamp(targetY, minY, maxY);

        Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);

        Vector3 currentPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        transform.position = currentPosition;
    }
}
