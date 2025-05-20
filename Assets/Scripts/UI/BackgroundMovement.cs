using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float parallaxFactorY = 0.2f;
    public Transform cameraTransform;

    private Vector3 lastCameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        transform.position += new Vector3(0f, deltaMovement.y * parallaxFactorY, 0f);

        lastCameraPosition = cameraTransform.position;
    }
}
