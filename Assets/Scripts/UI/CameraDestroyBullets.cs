using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDestroyBullets : MonoBehaviour
{
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsVisibleFrom(mainCamera))
        {
            Destroy(gameObject);
        }
    }

    bool IsVisibleFrom(Camera Camera)
    {
        Vector3 viewportPos = Camera.WorldToViewportPoint(transform.position);

        return viewportPos.x >= 0 && viewportPos.x <= 1 &&
        viewportPos.y >= 0 && viewportPos.y <= 1 &&
        viewportPos.z > 0;
    }
}
