using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClamp : MonoBehaviour
{
    private Camera mainCamera;
    private float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ClampPosition();
    } 

    void ClampPosition()
    {
        float zDepth = transform.position.z;

        Vector3 camPos = mainCamera.transform.position;

        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        minX = camPos.x - camWidth;
        maxX = camPos.x + camWidth;
        minY = camPos.y - camHeight;
        maxY = camPos.y + camHeight;

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);

        transform.position = clampedPosition;
    }
}
