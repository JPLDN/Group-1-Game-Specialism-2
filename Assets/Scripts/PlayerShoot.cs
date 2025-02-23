using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootingPoint;
    public float normalFireRate = 0.5f;
    public float powerUpFireRate = 0.2f;
    private float currentFireRate;
    private bool isPowerUpActive = false;

    private float nextFireTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentFireRate = normalFireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            nextFireTime = Time.time + currentFireRate;
        }
    }

    void Shoot()
    {
        if (isPowerUpActive)
        {
            ShootMultipleBullets();
        }
        else
        {
            Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
        }
    }

    void ShootMultipleBullets()
    {
        float spreadAngle = 15f;

        Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);

        Quaternion leftRotation = Quaternion.Euler(0, -spreadAngle, 0);
        Instantiate(bullet, shootingPoint.position, shootingPoint.rotation * leftRotation);

        Quaternion rightRotation = Quaternion.Euler(0, spreadAngle, 0);
        Instantiate(bullet, shootingPoint.position, shootingPoint.rotation * rightRotation);
    }

    public void ActivatePowerUp(float duration)
    {
        isPowerUpActive = true;
        currentFireRate = powerUpFireRate;
        StartCoroutine(DeactivatePowerUp(duration));
    }

    private IEnumerator DeactivatePowerUp(float duration)
    {
        yield return new WaitForSeconds(duration);
        isPowerUpActive = false;
        currentFireRate = normalFireRate;
    }
}
