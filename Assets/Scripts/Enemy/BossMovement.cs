using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Vector3 onScreenPosition;
    public float entrySpeed = 5;
    public float verticalMoveRange = 3f;
    public float verticalMoveSpeed = 3f;

    private Vector3 spawnPosition;
    private bool isEntering = true;
    private float baseY;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        float camHeight = cam.orthographicSize * 2f;
        float camWidth = camHeight * cam.aspect;

        spawnPosition = new Vector3(onScreenPosition.x, cam.transform.position.y + cam.orthographicSize + 2f, onScreenPosition.z);
        transform.position = spawnPosition;

        baseY = onScreenPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEntering)
        {
            transform.position = Vector3.MoveTowards(transform.position, onScreenPosition, entrySpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, onScreenPosition) < 0.01f)
            {
                isEntering = false;
            }
        }
        else
        {
            float newY = baseY + Mathf.Sin(Time.time * verticalMoveSpeed) * verticalMoveRange;
            transform.position = new Vector3(onScreenPosition.x, newY, onScreenPosition.z);
        }
    }
}
